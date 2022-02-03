

namespace Oxide.Ext.GamingEventApi
{
    using NATS.Client;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Timers;
    public class GamingEventApiNats : Asyncapi.Nats.Client.NatsClient
    {
        private static GamingEventApiNats instance = null;
        private class Imp : Asyncapi.Nats.Client.LoggingInterface
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
        private GamingEventApiNats(Asyncapi.Nats.Client.LoggingInterface logger)
        {
            this.Logger = logger;
            Options opts = ConnectionFactory.GetDefaultOptions();
            opts.AsyncErrorEventHandler += (sender, args) =>
            {
                this.Logger.Error("NATS: Error: ");
                this.Logger.Error("NATS:    Server: " + args.Conn.ConnectedUrl);
                this.Logger.Error("NATS:    Message: " + args.Error);
                this.Logger.Error("NATS:    Subject: " + args.Subscription.Subject);
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
        private GamingEventApiNats() : this(new Imp())
        {
        }

        private string GetNatsHost()
        {
            var envName = "BLACKHAWK_SERVER_NATS_HOST";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Console.WriteLine($"NATS: {envName} environment variable not sat using default value.");
                return "nats://localhost:42222";
            }
            else
            {
                return value;
            }
        }
        private string GetServerId()
        {
            
            var envName = "BLACKHAWK_SERVER_ID";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Console.WriteLine($"NATS: {envName} environment variable not sat using default value.");
                return "" + 0;
            }
            else
            {
                return value;
            }
        }
        private string GetNatsNkeyUser()
        {
            var envName = $"BLACKHAWK_SERVER_{GetServerId()}_NATS_NKEY_USER"; 
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Console.WriteLine($"NATS: {envName} environment variable not sat using default value.");
                return "UCNCZJYZY7EHLN64DBIEWJVLJGL5T3JFK7OAUXXCH7XJM337LEVFOSCX";
            }
            else{
                return value;
            }
        }
        private string GetNatsNkeySeed()
        {
            var envName = $"BLACKHAWK_SERVER_{GetServerId()}_NATS_NKEY_SEED";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Console.WriteLine($"NATS: {envName} environment variable not sat using default value.");
                return "SUACNAC2QZKPXKLKOE3TM3OPZ45P6VGQDVUPBLMFZEMKFPBBVHMLDOKFCQ";
            }
            else
            {
                return value;
            }
        }
        #region Singleton
        static ReaderWriterLock rwl = new ReaderWriterLock();
        static int timeOut = 5000;
        public static GamingEventApiNats SetInstance()
        {
            try
            {
                rwl.AcquireWriterLock(timeOut);
                try
                {
                    instance = new GamingEventApiNats();
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
        public static GamingEventApiNats SetInstance(Asyncapi.Nats.Client.LoggingInterface logger)
        {
            try
            {
                rwl.AcquireWriterLock(timeOut);
                try
                {
                    instance = new GamingEventApiNats(logger);
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
        public static GamingEventApiNats GetInstance()
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
