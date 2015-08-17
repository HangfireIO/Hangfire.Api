using System;
using System.Collections.Generic;
using Hangfire;
using Hangfire.States;

namespace Samples
{
    public class States
    {
        public void CreateInEnqueuedState()
        {
            #region EnqueuedState #1
            var client = new BackgroundJobClient();
            var state = new EnqueuedState("critical"); // Use the "critical" queue
             
            client.Create(() => Console.WriteLine("Hello!"), state);
            #endregion
        }

        public void ChangeToEnqueuedState()
        {
            var jobId = "someid";

            #region EnqueuedState #2
            var client = new BackgroundJobClient();
            var state = new EnqueuedState(); // Use the default queue
            
            client.ChangeState(jobId, state, FailedState.StateName);
            #endregion
        }

        public void ChangeToDeletedState()
        {
            #region DeletedState
            var client = new BackgroundJobClient();
            var jobId = client.Enqueue(() => Console.WriteLine("Hello"));

            var state = new DeletedState();
            client.ChangeState(jobId, state, EnqueuedState.StateName);
            #endregion
        }

        #region FaultedState
        public class FaultedState : IState
        {
            public static readonly string StateName = "Faulted";

            public FaultedState(Exception exception)
            {
                Message = exception.Message;
                Details = exception.ToString();
            }

            public string Name => StateName;
            public string Reason { get; set; }
            
            public bool IsFinal => true;
            public bool IgnoreJobLoadException => true;

            // Here are our custom properties, we'll made them
            // accessible through the Dashboard UI.
            public string Message { get; }
            public string Details { get; }

            public Dictionary<string, string> SerializeData()
            {
                return new Dictionary<string, string>
                {
                    { "Message", Message },
                    { "Details", Details }
                };
            }
        }
        #endregion
    }
}
