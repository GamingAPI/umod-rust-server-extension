using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using Oxide.Ext.GamingApi.MessageQueue;
using System;
using AsyncVerifyForMoq;
using Moq;

namespace Oxide.Ext.GamingApi.Tests
{
    [TestFixture()]
    public class GamingApiMessageQueueTest
    {
        GamingApiMessageQueue queue;

        [SetUp()]
        public void setup()
        {
            queue = GamingApiMessageQueue.Instance;
        }

        [Test()]
        public async Task shouldConsumeMessage()
        {
            var timeSpan = TimeSpan.FromSeconds(10);
            var mock = new Mock<Action<Action, Action>>();
            mock.Setup((m) => m(It.IsAny<Action>(), It.IsAny<Action>()))
                .Callback((Action success, Action failure) => success());

            queue.AddToMessageQueue(MessageImportance.LOW, mock.Object);

            var asyncVerification = new List<Task>()
            {
                MoqAsyncVerifyExtensions.SomeVerifyWithTimeout(() =>
                {
                    //Cannot use assertion as it will be caught by the test itself
                    if(0 != queue.GetCurrentMessagesInQueue()) throw new Exception($"{queue.GetCurrentMessagesInQueue()}");
                }, timeSpan)
            };
            await Task.WhenAll(asyncVerification);
        }
        [Test()]
        public async Task shouldConsumeRetryMessage()
        {
            var timeSpan = TimeSpan.FromSeconds(10);
            var mock = new Mock<Action<Action, Action>>();
            mock.Setup((m) => m(It.IsAny<Action>(), It.IsAny<Action>()))
                .Callback((Action success, Action failure) => success());

            queue.AddToRetryMessageQueue(MessageImportance.LOW, mock.Object);

            var asyncVerification = new List<Task>()
            {
                MoqAsyncVerifyExtensions.SomeVerifyWithTimeout(() =>
                {
                    //Cannot use assertion as it will be caught by the test itself
                    if(0 != queue.GetCurrentMessagesInQueue()) throw new Exception($"{queue.GetCurrentMessagesInQueue()}");
                }, timeSpan)
            };
            await Task.WhenAll(asyncVerification);
        }
        [Test()]
        public async Task shouldBeAbleToProcessMessagesInDueTime()
        {
            var timeSpan = TimeSpan.FromSeconds(12);
            queue.SetInterval(1000);
            var mock = new Mock<Action<Action, Action>>();
            mock.Setup((m) => m(It.IsAny<Action>(), It.IsAny<Action>()))
                .Callback((Action success, Action failure) => success());

            for (int i = 0; i < 10; i++)
            {
                queue.AddToRetryMessageQueue(MessageImportance.LOW, mock.Object);
            }

            var asyncVerification = new List<Task>()
            {
                MoqAsyncVerifyExtensions.SomeVerifyWithTimeout(() =>
                {
                    //Cannot use assertion as it will be caught by the test itself
                    if(0 != queue.GetCurrentMessagesInQueue()) throw new Exception($"{queue.GetCurrentMessagesInQueue()}");
                }, timeSpan)
            };
            await Task.WhenAll(asyncVerification);
        }
    }
}