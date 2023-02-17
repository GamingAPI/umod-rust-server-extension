// Reference: Newtonsoft.Json
// Reference: NATS.Client
// Reference: RustGameAPI

using NATS.Client;
using System;
using System.Diagnostics;
using System.Threading;
using Asyncapi.Nats.Client;
using NATS.Client.JetStream;
using System.Configuration;
using System.IO;
using System.Text;
using UnityEngine;

namespace Oxide.Ext.GamingApi
{
    public class GamingApiNats : NatsClient
    {
        private static GamingApiNats instance = null;
        private class Imp : LoggingInterface
        {
            public void Debug(string m)
            {
                Trace.WriteLine(m);
            }

            public void Error(string m)
            {
                Trace.WriteLine(m);
            }

            public void Info(string m)
            {
                Trace.WriteLine(m);
            }
        }
        private GamingApiNats(LoggingInterface logger)
        {
            this.Logger = logger;
            Options opts = ConnectionFactory.GetDefaultOptions();
            opts.AllowReconnect = true;
            opts.MaxReconnect = Options.ReconnectForever;
            // 30s wait
            opts.ReconnectWait = 1000 * 30;
            opts.AsyncErrorEventHandler += (sender, args) =>
            {
                this.Logger.Error("NATS: Error: ");
                this.Logger.Error("NATS:    Server: " + args.Conn.ConnectedUrl);
                this.Logger.Error("NATS:    Message: " + args.Error);
                this.Logger.Error("NATS:    Subject: " + args.Subscription?.Subject);
            };

            opts.ServerDiscoveredEventHandler += (sender, args) =>
            {
                this.Logger.Error("NATS: A new server has joined the cluster:");
                this.Logger.Error("NATS:     " + String.Join(", ", args.Conn.DiscoveredServers));
            };

            opts.ClosedEventHandler += (sender, args) =>
            {
                this.Logger.Error("NATS: Connection Closed: ");
                this.Logger.Error("NATS:    Server: " + args.Conn.ConnectedUrl);
            };

            opts.DisconnectedEventHandler += (sender, args) =>
            {
                this.Logger.Error("NATS: Connection Disconnected: ");
                this.Logger.Error("NATS:    Server: " + args.Conn.ConnectedUrl);
            };
            opts.Url = this.GetNatsHost();
            string authenticationType = GetNatsAuthenticationType();
            if(authenticationType == "jwt") {
                string NatsJwtUserFile = this.GetNatsJwtUserFile();
                if (NatsJwtUserFile == null)
                {
                    EventHandler<UserJWTEventArgs> jwtEh = (sender, args) =>
                    {
                        // Obtain a user JWT...
                        string jwt = this.GetNatsJwtUser();

                        this.Logger.Info("NATS: Loading jwt token : " + jwt);
                        // You must set the JWT in the args to hand off
                        // to the client library.
                        args.JWT = jwt;
                    };

                    EventHandler<UserSignatureEventArgs> sigEh = (sender, args) =>
                    {
                        // get a private key seed from your environment.
                        string seed = this.GetNatsJwtSeed();
                        this.Logger.Info("NATS: Loading jwt seed : " + seed.Substring(0, 3) + "....");

                        // Generate a NkeyPair
                        NkeyPair kp = Nkeys.FromSeed(seed);

                        // Sign the nonce and return the result in the SignedNonce
                        // args property.  This must be set.
                        args.SignedNonce = kp.Sign(args.ServerNonce);
                    };
                    opts.SetUserCredentialHandlers(jwtEh, sigEh);
                } else
                {
                    string NatsJwtSeedFile = this.GetNatsJwtSeedFile();
                    opts.SetUserCredentials(NatsJwtUserFile, NatsJwtSeedFile);
                }
            } else
            {
                // NKey authentication
                EventHandler<UserSignatureEventArgs> sigEh = (sender, args) =>
                {
                    // get a private key seed from your environment.
                    string seed = this.GetNatsNkeySeed();

                    // Generate a NkeyPair
                    NkeyPair kp = Nkeys.FromSeed(seed);

                    // Sign the nonce and return the result in the SignedNonce
                    // args property.  This must be set.
                    args.SignedNonce = kp.Sign(args.ServerNonce);
                };
                opts.SetNkey(this.GetNatsNkeyUser(), sigEh);
            }
            this.Connect(opts);
            var jetstreamOptions = JetStreamOptions.Builder().Build();
            this.createJetStreamContext(jetstreamOptions);
        }
        private GamingApiNats() : this(new Imp())
        {
        }

        private string GetNatsHost()
        {
            var envName = "GAMINGAPI_NATS_SERVER_HOST";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                this.Logger.Info($"NATS: {envName} environment variable not sat using default value.");
                return "nats://localhost:4222";
            }
            this.Logger.Info($"NATS: {envName} loading - {value}");
            return value;
        }

        /// <summary>
        /// Get the type of authentication used on the NATS server.
        /// 
        /// "jwt" or "nkey"
        /// </summary>
        /// <returns></returns>
        private string GetNatsAuthenticationType()
        {
            var envName = $"GAMINGAPI_NATS_AUTHENTICATION_TYPE";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                this.Logger.Info($"NATS: {envName} environment variable not sat using default value.");
                return "jwt";
            }
            this.Logger.Info($"NATS: {envName} loading - {value}");
            return value;
        }

        private string GetNatsNkeyUser()
        {
            var envName = $"GAMINGAPI_NATS_NKEY_USER"; 
            var value = Environment.GetEnvironmentVariable(envName);
            this.Logger.Info($"NATS: {envName} loading");
            if (value == null)
            {
                this.Logger.Info($"NATS: {envName} environment variable not sat using default value.");
                return "UCNCZJYZY7EHLN64DBIEWJVLJGL5T3JFK7OAUXXCH7XJM337LEVFOSCX";
            }
            return value;
        }

        private string GetNatsNkeySeed()
        {
            var envName = $"GAMINGAPI_NATS_NKEY_SEED";
            var value = Environment.GetEnvironmentVariable(envName);
            this.Logger.Info($"NATS: {envName} loading");
            if (value == null)
            {
                this.Logger.Info($"NATS: {envName} environment variable not sat using default value.");
                return "SUACNAC2QZKPXKLKOE3TM3OPZ45P6VGQDVUPBLMFZEMKFPBBVHMLDOKFCQ";
            }
            return value;
        }
        public string PrintByteArray(byte[] bytes)
        {
            var sb = new StringBuilder("new byte[] { ");
            foreach (var b in bytes)
            {
                sb.Append(b + ", ");
            }
            sb.Append("}");
            return sb.ToString();
        }
        private string GetNatsJwtUserFile()
        {
            var envName = $"GAMINGAPI_NATS_JWT_USER_FILE";
            var fileName = Environment.GetEnvironmentVariable(envName);
            return fileName;
        }
        private string GetNatsJwtUser()
        {
            var envName = $"GAMINGAPI_NATS_JWT_USER";

            var value = Environment.GetEnvironmentVariable(envName);
            this.Logger.Info($"NATS: {envName} loading");
            if (value == null)
            {
                this.Logger.Info($"NATS: {envName} environment variable not sat using default value.");
                return "J0eXAiOiJKV1QiLCJhbGciOiJlZDI1NTE5LW5rZXkifQ.eyJqdGkiOiJTWDU1RkYzQ1NTQ1ZXU1lIS0lMQUtJRVZWQlhJVFZTMlJWQTdOWEhNTlJIQUhRNFFWVDdRIiwiaWF0IjoxNjczMTU3ODQ2LCJpc3MiOiJBQk9OUEpWTkI3UzRZTFpKUTVUWkNZRzVKWkQ2T09CRFIyNlVUVzZUSFg3T1dDVVNFU1pSUkhGRiIsIm5hbWUiOiJydXN0X3NlcnZlciIsInN1YiI6IlVDRVJWT1hRMlFGNkRBWEdDNVZNUDJYWEczWTVJQjdBN1RGQ1hFTEVHT1ZXRTRHV0lFRkNRSzZXIiwibmF0cyI6eyJwdWIiOnsiYWxsb3ciOlsidjAucnVzdC5zZXJ2ZXJzLlx1MDAzZSJdfSwic3ViIjp7ImFsbG93IjpbIl9JTkJPWC5cdTAwM2UiXX0sInJlc3AiOnsibWF4IjoxLCJ0dGwiOjB9LCJzdWJzIjotMSwiZGF0YSI6LTEsInBheWxvYWQiOi0xLCJ0eXBlIjoidXNlciIsInZlcnNpb24iOjJ9fQ.VRXdyowAR1Nb8-i0OMyI9jll3hU3kIm7BPIaas-xsJkT0eD_DhBd2hxEQBtHS8cCqp7M9SwYYKL-wIb6baOjAw";
            }
            return value;
        }

        private string GetNatsJwtSeedFile()
        {
            var envName = $"GAMINGAPI_NATS_JWT_SEED_FILE";
            var fileName = Environment.GetEnvironmentVariable(envName);
            return fileName;
        }
        private string GetNatsJwtSeed()
        {
            var envName = $"GAMINGAPI_NATS_JWT_SEED";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                this.Logger.Info($"NATS: {envName} environment variable not sat using default value.");
                return "SUAIDAQVH67GXNFUALIVHFKC24SZCFR3BZF3GGHYVQDHVB3CG3GDGVWPUM";
            }
            return value;
        }

        #region Singleton
        static ReaderWriterLock rwl = new ReaderWriterLock();
        static int timeOut = 5000;
        public static GamingApiNats SetInstance()
        {
            try
            {
                rwl.AcquireWriterLock(timeOut);
                try
                {
                    instance = new GamingApiNats();
                    return instance;
                }
                finally
                {
                    // Ensure that the lock is released.
                    rwl.ReleaseWriterLock();
                }
            }
            catch (ApplicationException ae)
            {
                throw ae;
            }
        }
        public static GamingApiNats SetInstance(LoggingInterface logger)
        {
            try
            {
                rwl.AcquireWriterLock(timeOut);
                try
                {
                    instance = new GamingApiNats(logger);
                    return instance;
                }
                finally
                {
                    // Ensure that the lock is released.
                    rwl.ReleaseWriterLock();
                }
            }
            catch (ApplicationException ae)
            {
                throw ae;
            }
        }
        public static GamingApiNats GetInstance()
        {
            try
            {
                rwl.AcquireReaderLock(timeOut);
                try
                {
                    return instance;
                }
                finally
                {
                    // Ensure that the lock is released.
                    rwl.ReleaseReaderLock();
                }
            }
            catch (ApplicationException ae)
            {
                throw ae;
            }
        }
        #endregion
    }
}
