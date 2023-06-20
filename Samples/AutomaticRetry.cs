using Hangfire;

namespace Samples
{
    class AutomaticRetry
    {
        #region Disable Retries
        [AutomaticRetry(Attempts = 0)]
        public void RetriesDisabled(string arg)
        {
        }
        #endregion

        public void OverrideDefault()
        {
            #region Override Default
            // Call it in the application initialization logic
            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3 });
            #endregion
        }

        #region Attempts Exceeded
        [AutomaticRetry(OnAttemptsExceeded = AttemptsExceededAction.Delete)]
        public void DeleteWhenAttemptsExceeded()
        {
        }
        #endregion
    }
}
