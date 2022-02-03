using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;

namespace Oxide.Ext.GamingEventApi.MessageQueue
{
    public sealed class GamingEventApiMessageQueue
    {
        //The two types of message queue's with the given message importance.
        private readonly Dictionary<MessageImportance, Queue<Action<Action, Action>>> retryMessageQueue;
        private readonly Dictionary<MessageImportance, Queue<Action<Action, Action>>> messageQueue;
        private int currentMessageCount = 0;
        private Timer queueTimer;
        Boolean shouldRetryMessageQueue = false;

        private GamingEventApiMessageQueue()
        {
            InitQueues(out retryMessageQueue);
            InitQueues(out messageQueue);
            queueTimer = new Timer();
            queueTimer.Elapsed += new ElapsedEventHandler(CallMessageInQueue);
            queueTimer.Interval = 100; // 10 messages a second
            queueTimer.Start();
        }

        /// <summary>
        /// Sets the ms between each request.
        /// Cannot be below 20 ms.
        /// messages per second = 1000 / interval
        /// </summary>
        /// <param name="interval"></param>
        public void SetInterval(double interval)
        {
            queueTimer.Interval = interval > 20 ? interval : 20;
        }



        /// <summary>
        /// Flushes all the messages by sending 100 messages a second.
        /// </summary>
        public void FlushMessages()
        {
            Console.WriteLine("GamingEventApiMessageQueue : FLUSHING MESSAGES");
            Timer flushTimer = new Timer();
            flushTimer.Elapsed += new ElapsedEventHandler(CallMessageInQueue);
            flushTimer.Interval = 10; // 100 messages a second
            //Ensure when no more messages to stop the timer.
            flushTimer.Elapsed += new ElapsedEventHandler((object source, ElapsedEventArgs e) =>
            {
                if (currentMessageCount == 0)
                {
                    flushTimer.Stop();
                    Console.WriteLine("GamingEventApiMessageQueue : DONE FLUSHING MESSAGES");
                }
            });
            flushTimer.Start();
        }

        /// <summary>
        /// Returns the number of messages currently in queue.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentMessagesInQueue()
        {
            return currentMessageCount;
        }

        private void InitQueues(out Dictionary<MessageImportance, Queue<Action<Action, Action>>> forDictionary)
        {
            forDictionary = new Dictionary<MessageImportance, Queue<Action<Action, Action>>>();
            foreach (MessageImportance messageImportance in (MessageImportance[])Enum.GetValues(typeof(MessageImportance)))
            {
                forDictionary.Add(messageImportance, new Queue<Action<Action, Action>>());
            }
        }


        private bool TryDequeueMessageToCall(Dictionary<MessageImportance, Queue<Action<Action, Action>>> dictionaryToSearch, out Action<Action, Action> outAction, out MessageImportance outMessageImportance)
        {
            foreach (MessageImportance messageImportance in (MessageImportance[])Enum.GetValues(typeof(MessageImportance)))
            {
                if (TryDequeueMessageToCall(messageImportance, dictionaryToSearch, out outAction, out outMessageImportance))
                {
                    return true;
                }
            }
            outAction = null;
            outMessageImportance = MessageImportance.UNKNOWN;
            return false;
        }

        private bool TryDequeueMessageToCall(MessageImportance importance, Dictionary<MessageImportance, Queue<Action<Action, Action>>> dictionaryToSearch, out Action<Action, Action> action, out MessageImportance messageImportance)
        {
            try
            {
                Queue<Action<Action, Action>> queueToCheck;
                if (dictionaryToSearch.TryGetValue(importance, out queueToCheck))
                {
                    if (queueToCheck.Count != 0)
                    {
                        action = queueToCheck.Dequeue();
                        messageImportance = importance;
                        return true;
                    }
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("GamingEventApiMessageQueue : ArgumentNullException: " + e.ToString() + ", loosing message!!!!!!!!!!!!!!!!");
            }
            messageImportance = MessageImportance.UNKNOWN;
            action = null;
            return false;
        }

        /// <summary>
        /// Used by the timer, called each Timer.Interval ms.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void CallMessageInQueue(object source, ElapsedEventArgs e)
        {
            Action<Action, Action> actionToCall;
            MessageImportance messageImportance;
            if (shouldRetryMessageQueue)
            {
                if (TryDequeueMessageToCall(retryMessageQueue, out actionToCall, out messageImportance))
                {
                    //call the outAction which where next in line and end call to this method
                    actionToCall(() =>
                    {
                        //Message was successfull
                    }, () =>
                    {
                        //If action was not successfull, add it do the retryMessageQueue
                        AddMessageToQueue(retryMessageQueue, messageImportance, actionToCall);
                        shouldRetryMessageQueue = true;
                    });
                    currentMessageCount--;
                    return;
                }
            }

            if (TryDequeueMessageToCall(messageQueue, out actionToCall, out messageImportance))
            {
                //call the outAction with where next in line and end call to this method
                actionToCall(() =>
                {
                    //Message was successfull
                    currentMessageCount--;
                }, () =>
                {
                    //If action was not successfull, add it do the retryMessageQueue
                    AddMessageToQueue(retryMessageQueue, messageImportance, actionToCall);
                    shouldRetryMessageQueue = true;
                });
                currentMessageCount--;
                return;
            }
            else
            {
                //No messages to call, return;
            }
        }
        
        /// <summary>
        /// Adds a given action to a queue of some 
        /// </summary>
        /// <param name="dictionaryToSearch"></param>
        /// <param name="importance"></param>
        /// <param name="action"></param>
        private void AddMessageToQueue(Dictionary<MessageImportance, Queue<Action<Action, Action>>> dictionaryToSearch, MessageImportance importance, Action<Action, Action> action)
        {
            Queue<Action<Action, Action>> queue;
            if (dictionaryToSearch.TryGetValue(importance, out queue))
            {
                queue.Enqueue(action);
                currentMessageCount++;
            }
            else
            {
                Console.WriteLine("GamingEventApiMessageQueue : No queue found for message importance: " + importance.ToString() + ", loosing message!!!!!!!!!!!!!!!!");
            }
        }

        public void AddToRetryMessageQueue(MessageImportance importance, Action<Action, Action> action)
        {
            AddMessageToQueue(retryMessageQueue, importance, action);
        }
        public void AddToMessageQueue(MessageImportance importance, Action<Action, Action> action)
        {
            AddMessageToQueue(messageQueue, importance, action);
        }

        public static GamingEventApiMessageQueue Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly GamingEventApiMessageQueue instance = new GamingEventApiMessageQueue();
        }
    }
}
