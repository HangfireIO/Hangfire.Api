using System;
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
    }
}
