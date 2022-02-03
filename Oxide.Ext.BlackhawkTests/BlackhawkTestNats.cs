

namespace Oxide.Ext.BlackhawkTest
{
    
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Timers;
    public class BlackhawkTestNats : Asyncapi.Nats.TestClient.NatsTestClient
    {
        private static BlackhawkTestNats instance = null;

        private class Imp : Asyncapi.Nats.Client.LoggingInterface
        {
            public void Debug(string m)
            {
                Console.WriteLine(m);
            }

            public void Error(string m)
            {
                Console.WriteLine(m);
            }

            public void Info(string m)
            {
                Console.WriteLine(m);
            }
        }
        private BlackhawkTestNats()
        {
            this.Logger = new Imp();
        }


        #region Singleton
        public static BlackhawkTestNats getInstance()
        {
            if (instance == null)
            {
                instance = new BlackhawkTestNats();
            }
            return instance;
        }
        #endregion
    }
}
