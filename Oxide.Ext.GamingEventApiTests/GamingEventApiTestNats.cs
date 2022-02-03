

namespace Oxide.Ext.GamingEventApiTest
{
    
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Timers;
    public class GamingEventApiTestNats : Asyncapi.Nats.TestClient.NatsTestClient
    {
        private static GamingEventApiTestNats instance = null;

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
        private GamingEventApiTestNats()
        {
            this.Logger = new Imp();
        }


        #region Singleton
        public static GamingEventApiTestNats getInstance()
        {
            if (instance == null)
            {
                instance = new GamingEventApiTestNats();
            }
            return instance;
        }
        #endregion
    }
}
