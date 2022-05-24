// Reference: Org.OpenAPITools
// Reference: NATS.Client
using Oxide.Core.Libraries;
using System;
using System.Collections.Generic;
using static Oxide.Core.Libraries.Timer;
using Oxide.Core;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;

namespace Oxide.Ext.GamingApi
{

    public class DefaultPluginInformation
    {
        public static String logoIcon = "76561198891307828";
        public static String linkColor = "#3573F2";
        public static String commandColor = "#E12DCB";
        public static String adminColor = "#E31818";
        public static String nameColor = "#ffffff";
        public static String statColor = "#E36753";
        public IPlayerApi PlayerApi { get; }
        public IServerApi ServerApi { get; }
        public GamingEventApiNats NatsClient { get; }

        private class Logger : Asyncapi.Nats.Client.LoggingInterface
        {
            public void Debug(string m)
            {
                Interface.Oxide.LogDebug("[GamingEventApi DefaultPluginInformation]" + m);
            }

            public void Error(string m)
            {
                Interface.Oxide.LogError("[GamingEventApi DefaultPluginInformation]" + m);
            }

            public void Info(string m)
            {
                Interface.Oxide.LogInfo("[GamingEventApi DefaultPluginInformation]" + m);
            }
        }

        private DefaultPluginInformation()
        {
            ApiClient client = new ApiClient();
            client.RestClient.Timeout = 20000;
            Configuration config = new Configuration();
            config.ApiKey.Add("Bearer", "" + GetApiToken());
            config.ApiKeyPrefix.Add("Bearer", "Bearer");
            config.AddDefaultHeader("content-type", "application/json");
            config.BasePath = DefaultPluginInformation.GetApiBasePath();
            PlayerApi = new PlayerApi(config);
            ServerApi = new ServerApi(config);
            this.NatsClient = GamingEventApiNats.SetInstance(new Logger());
        }



        public static string GetApiBasePath()
        {
            var envName = "BLACKHAWK_SERVER_API_BASE_PATH";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Interface.Oxide.LogInfo($"{envName} environment variable not sat using default value.");
                return "https://www.rustblackhawk.com/api";
            }
            else
            {
                return value;
            }
        }

        public static string GetApiToken()
        {
            var envName = "BLACKHAWK_SERVER_API_KEY";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Interface.Oxide.LogInfo($"{envName} environment variable not sat using default value.");
                return "Token";
            }
            else
            {
                return value;
            }
        }
        public static string GetServerId()
        {
            var envName = "BLACKHAWK_SERVER_ID";
            var value = Environment.GetEnvironmentVariable(envName);
            if (value == null)
            {
                Interface.Oxide.LogInfo($"{envName} environment variable not sat using default value.");
                return "" + 0;
            }
            else
            {
                return value;
            }
        }



        //Timers if no message from api
        private Dictionary<int, TimerInstance> timers = new Dictionary<int, TimerInstance>();
        private int nextTimeId = 0;
        public void RemoveTimer(int timerId)
        {
            //Incase a timer is running, destroy it before removing it.
            TimerInstance currentTimer;
            Boolean success = timers.TryGetValue(timerId, out currentTimer);
            if (success)
            {
                currentTimer.Destroy();
            }
            timers.Remove(timerId);
        }
        private void SetTimer(string steamId, string[] messages, int retryTime, int timerId, Action<string> messageToSend)
        {
            //Scale the delay with a factor 3
            float delay = 3f * (retryTime + 1);
            TimerInstance playerTimer = new Timer().Once(delay, () =>
            {
                messageToSend(messages[retryTime]);
                //If we have more messages to work with use them.
                if (retryTime + 1 < messages.Length)
                {
                    SetTimer(steamId, messages, retryTime + 1, timerId, messageToSend);
                }
                else
                {
                    //this was the last timer, remove the resource
                    timers.Remove(timerId);
                }
            });
            //If timer already exist remove it first
            timers.Remove(timerId);
            timers.Add(timerId, playerTimer);
        }
        public int SetTimer(string steamId, string[] messages, Action<string> messageToSend)
        {
            int timerId = nextTimeId++;
            SetTimer(steamId, messages, 0, timerId, messageToSend);
            return timerId;
        }



        #region Singleton
        private static System.Threading.ReaderWriterLock rwl = new System.Threading.ReaderWriterLock();
        private static int timeOut = 5000;
        private static DefaultPluginInformation instance;
        public static DefaultPluginInformation GetInstance()
        {
            try
            {
                rwl.AcquireReaderLock(timeOut);
                try
                {
                    if (instance != null)
                    {
                        return instance;
                    }
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

            //Aquire writer
            try
            {
                rwl.AcquireWriterLock(timeOut);
                try
                {
                    if(instance != null)
                    {
                        return instance;
                    }
                    else
                    {
                        instance = new DefaultPluginInformation();
                        return instance;
                    }
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
        #endregion
    }
}
