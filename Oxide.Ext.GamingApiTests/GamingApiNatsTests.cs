using Asyncapi.Nats.Client;
using NATS.Client;
using NATS.Client.JetStream;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Oxide.Ext.GamingApi.Tests
{
    [TestFixture()]
    public class GamingApiNatsTests
    {
        GamingApiNats blackhawkNats;

        [SetUp()]
        public void setup()
        {
            Environment.SetEnvironmentVariable("GAMINGAPI_NATS_NKEY_USER", "UCI2NCSIEV3DXLYYR5KQXYCZ7CIW4KYXHLSGXJOZ7TSRRKHP2BM5IVMU");
            Environment.SetEnvironmentVariable("GAMINGAPI_NATS_NKEY_SEED", "SUAHZGQCK3PKMY5JBY2PBJUK2SA2IAGNX7VXYQJ75MLIU2IWQE235OBLJM");
            blackhawkNats = GamingApiNats.SetInstance();
        }

        [TearDown()]
        public void teardown()
        {
            blackhawkNats?.Close();
        }

        [Test()]
        [Ignore("For now")]
        public void shouldSetup()
        {
            NatsClient instance = new NatsClient();
            Options opts = ConnectionFactory.GetDefaultOptions();

            opts.Url = "nats://localhost:4222";
            EventHandler<UserSignatureEventArgs> sigEh = (sender, args) =>
            {
                // get a private key seed from your environment.
                string seed = "SUAHZGQCK3PKMY5JBY2PBJUK2SA2IAGNX7VXYQJ75MLIU2IWQE235OBLJM";

                // Generate a NkeyPair
                NkeyPair kp = Nkeys.FromSeed(seed);

                // Sign the nonce and return the result in the SignedNonce
                // args property.  This must be set.
                args.SignedNonce = kp.Sign(args.ServerNonce);
            };
            opts.SetNkey("UCI2NCSIEV3DXLYYR5KQXYCZ7CIW4KYXHLSGXJOZ7TSRRKHP2BM5IVMU", sigEh);
            instance.Connect(opts);
        }

        [Test()]
        public void replyToRustApiprocessServersServerIdEventsStartedTest()
        {
            Assert.IsTrue(blackhawkNats.IsConnected());
            blackhawkNats.PublishToV0RustServersServerIdEventsStarted("101");
        }




        [Test()]
        public void randomTest()
        {
            Options opts = ConnectionFactory.GetDefaultOptions();

            opts.Url = "nats://localhost:4222";
            EventHandler<UserSignatureEventArgs> sigEh = (sender, args) =>
            {
                // get a private key seed from your environment.
                string seed = "SUAHZGQCK3PKMY5JBY2PBJUK2SA2IAGNX7VXYQJ75MLIU2IWQE235OBLJM";

                // Generate a NkeyPair
                NkeyPair kp = Nkeys.FromSeed(seed);

                // Sign the nonce and return the result in the SignedNonce
                // args property.  This must be set.
                args.SignedNonce = kp.Sign(args.ServerNonce);
            };
            opts.SetNkey("UCI2NCSIEV3DXLYYR5KQXYCZ7CIW4KYXHLSGXJOZ7TSRRKHP2BM5IVMU", sigEh);
            var c = new ConnectionFactory().CreateConnection(opts);
            IJetStream js = c.CreateJetStreamContext();
            var message = new Asyncapi.Nats.Client.Models.ChatMessage();
            message.PlayerName = "test";
            var json = JsonSerializer.Serialize(message);
            var bytes = Encoding.UTF8.GetBytes(json);
            js.Publish("v0.rust.servers.101.events.player.123.chatted", bytes);
        }

    }
}