using NATS.Client;
using System;
using System.Diagnostics;
using System.Threading;
using Asyncapi.Nats.Client;

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
            this.Connect(opts);
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
                Console.WriteLine($"NATS: {envName} environment variable not sat using default value.");
                return "nats://localhost:4222";
            }
            return value;
        }
        private string GetNatsNkeyUser()
        {
            var envName = $"GAMINGAPI_NATS_NKEY_USER"; 
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Console.WriteLine($"NATS: {envName} environment variable not sat using default value.");
                return "UCNCZJYZY7EHLN64DBIEWJVLJGL5T3JFK7OAUXXCH7XJM337LEVFOSCX";
            }
            return value;
        }
        private string GetNatsNkeySeed()
        {
            var envName = $"GAMINGAPI_NATS_NKEY_SEED";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Console.WriteLine($"NATS: {envName} environment variable not sat using default value.");
                return "SUACNAC2QZKPXKLKOE3TM3OPZ45P6VGQDVUPBLMFZEMKFPBBVHMLDOKFCQ";
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
