

namespace Oxide.Ext.GamingApiTest
{
    
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Timers;
    public class GamingApiTestNats : Asyncapi.Nats.TestClient.NatsTestClient
    {
        private static GamingApiTestNats instance = null;

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
        private GamingApiTestNats()
        {
            this.Logger = new Imp();
        }


        #region Singleton
        public static GamingApiTestNats getInstance()
        {
            if (instance == null)
            {
                instance = new GamingApiTestNats();
            }
            return instance;
        }
        #endregion
    }
}
