using NATS.Client;
using System;

namespace Oxide.Ext.GamingApiTest
{
    
    public class GamingApiTestNats : Asyncapi.
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
