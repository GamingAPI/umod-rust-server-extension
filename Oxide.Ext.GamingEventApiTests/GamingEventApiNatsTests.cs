using NATS.Client;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Oxide.Ext.GamingEventApi.Tests
{
    [TestFixture()]
    public class GamingEventApiNatsTests
    {
        public static string GetConfigDir()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            var evan = System.Environment.CurrentDirectory;
            var configDirPath = Path.Combine(evan, "../../setup");
            if (!Directory.Exists(configDirPath))
                throw new DirectoryNotFoundException($"The Config dir was not found at: '{configDirPath}'.");

            return configDirPath;
        }

        GamingEventApiNats blackhawkNats;
        GamingEventApiTestNats blackhawkTestNats;
        AutoResetEvent stopWaitHandle = new AutoResetEvent(false);
        [SetUp()]
        public void setup()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            blackhawkNats = GamingEventApiNats.GetInstance();
            Trace.AutoFlush = true;
            Trace.Indent();
            blackhawkTestNats = GamingEventApiTestNats.getInstance();
            Options opts = ConnectionFactory.GetDefaultOptions();
            opts.AsyncErrorEventHandler += (sender, args) =>
            {
                Trace.WriteLine("Error: ");
                Trace.WriteLine("   Server: " + args.Conn.ConnectedUrl);
                Trace.WriteLine("   Message: " + args.Error);
                Trace.WriteLine("   Subject: " + args.Subscription.Subject);
            };

            opts.ServerDiscoveredEventHandler += (sender, args) =>
            {
                Trace.WriteLine("A new server has joined the cluster:");
                Trace.WriteLine("    " + String.Join(", ", args.Conn.DiscoveredServers));
            };

            opts.ClosedEventHandler += (sender, args) =>
            {
                Trace.WriteLine("Connection Closed: ");
                Trace.WriteLine("   Server: " + args.Conn.ConnectedUrl);
            };

            opts.DisconnectedEventHandler += (sender, args) =>
            {
                Trace.WriteLine("Connection Disconnected: ");
                Trace.WriteLine("   Server: " + args.Conn.ConnectedUrl);
            };
            opts.Url = "nats://localhost:42222";
            
            var configDirPath = Path.Combine(GetConfigDir(), "user.nk");
            EventHandler<UserSignatureEventArgs> sigEh = (sender, args) =>
            {
                // get a private key seed from your environment.
                string seed = "SUACNAC2QZKPXKLKOE3TM3OPZ45P6VGQDVUPBLMFZEMKFPBBVHMLDOKFCQ";

                // Generate a NkeyPair
                NkeyPair kp = Nkeys.FromSeed(seed);

                // Sign the nonce and return the result in the SignedNonce
                // args property.  This must be set.
                args.SignedNonce = kp.Sign(args.ServerNonce);
            };
            opts.SetNkey("UCNCZJYZY7EHLN64DBIEWJVLJGL5T3JFK7OAUXXCH7XJM337LEVFOSCX", sigEh);
            blackhawkNats.Connect(opts);
            blackhawkTestNats.Connect(opts);
        }
        [TearDown()]
        public void teardown()
        {
            blackhawkNats.Close();
        }
        [Test()]
        public void SubscribeToRustServersServerIdPlayersSteamIdTitlesAquiredTest()
        {
            AutoResetEvent stopWaitHandle = new AutoResetEvent(false);
            Assert.IsTrue(blackhawkNats.IsConnected());
            Assert.IsTrue(blackhawkTestNats.IsConnected());
            String gotServerId = string.Empty;
            String gotSteamId = string.Empty;
            PublishForServerPlayerTitleAcquired gotMessage = new PublishForServerPlayerTitleAcquired();
            String serverId = "1234";
            String steamId = "test";
            var test = new RustServersServerIdPlayersSteamIdTitlesAquiredOnRequest((PublishForServerPlayerTitleAcquired request, string server_id, string steam_id) =>
            {
                gotServerId = server_id;
                gotSteamId = steam_id;
                gotMessage = request;
                stopWaitHandle.Set();
            });
            blackhawkNats.SubscribeToRustServersServerIdPlayersSteamIdTitlesAquired(test, "*", "*");
            var message = new PublishForServerPlayerTitleAcquired();
            message.Description = "description";
            message.SteamId = "TEst";
            message.Title = "TitleTest";
            message.TitleColor = "#21321";
            message.TitleId = 21;
            blackhawkTestNats.PublishToRustServersServerIdPlayersSteamIdTitlesAquired(message, serverId, steamId);
            stopWaitHandle.WaitOne();
            Assert.AreEqual(serverId, gotServerId);
            Assert.AreEqual(steamId, gotSteamId);
            Assert.AreEqual(message.Description, gotMessage.Description);
            Assert.AreEqual(message.SteamId, gotMessage.SteamId);
            Assert.AreEqual(message.Title, gotMessage.Title);
            Assert.AreEqual(message.TitleColor, gotMessage.TitleColor);
            Assert.AreEqual(message.TitleId, gotMessage.TitleId);
        }

        [Test()]
        public void replyToRustApiprocessServersServerIdEventsStartedTest()
        {
            Assert.IsTrue(blackhawkNats.IsConnected());
            Assert.IsTrue(blackhawkTestNats.IsConnected());
            String gotServerId = string.Empty;
            var messageToReply = new ReplyForServerStarted();
            messageToReply.StatusMessage = "Everything ok";
            RustApiprocessServersServerIdEventsStartedOnRequest test = new RustApiprocessServersServerIdEventsStartedOnRequest((string server_id) =>
            {
                gotServerId = server_id;
                return messageToReply;
            });
            blackhawkTestNats.ReplyToRustApiprocessServersServerIdEventsStarted(test, "test");
            ReplyForServerStarted reply = blackhawkNats.RequestRustApiprocessServersServerIdEventsStarted("test");
            Trace.WriteLine(gotServerId);
            Assert.AreEqual("test", gotServerId);
            Assert.AreEqual(reply.StatusMessage, messageToReply.StatusMessage);
        }
        
    }
}