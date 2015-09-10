using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Owin;

namespace Samples
{
    class AppBuilderExtensions
    {
        public class BasicSetup
        {
            #region Basic Setup
            public void Configuration(IAppBuilder app)
            {
                GlobalConfiguration.Configuration
                    .UseSqlServerStorage(@"<your_connection_string>");

                app.UseHangfireServer();
                app.UseHangfireDashboard();
            }
            #endregion
        }

        public class DashboardOnly
        {
            #region Dashboard Only
            public void Configuration(IAppBuilder app)
            {
                // GlobalConfiguration usage was removed for clarity.
                app.UseHangfireDashboard();
            }
            #endregion
        }

        public class ChangeDashboardPath
        {
            #region Change Dashboard Path
            public void Configuration(IAppBuilder app)
            {
                // GlobalConfiguration usage was removed for clarity.
                app.UseHangfireDashboard("/admin/hangfire");
            }
            #endregion
        }

        public class ConfiguringAuthorization
        {
            #region Configuring Authorization
            // Install the Hangfire.Dashboard.Authorization NuGet package first.

            public void Configuration(IAppBuilder app)
            {
                // GlobalConfiguration usage was removed for clarity.
                var options = new DashboardOptions
                {
                    AuthorizationFilters = new [] 
                    {
                        new AuthorizationFilter { Roles = "admin" },
                    }
                };

                app.UseHangfireDashboard("/hangfire", options);
            }
            #endregion
        }

        public class ChangeApplicationPath
        {
            #region Change Application Path
            public void Configuration(IAppBuilder app)
            {
                // GlobalConfiguration usage was removed for clarity.
                var options = new DashboardOptions { AppPath = "/app" };
                app.UseHangfireDashboard("/hangfire", options);
            }
            #endregion
        }

        public class MultipleDashboards
        {
            #region Multiple Dashboards
            public void Configuration(IAppBuilder app)
            {
                // GlobalConfiguration.UseStorage isn't necessary here,
                // because you are passing a storage instance explicitly.
                var storage1 = new SqlServerStorage(@"connection_string_1");
                var storage2 = new SqlServerStorage(@"connection_string_2");

                app.UseHangfireDashboard("/hangfire1", new DashboardOptions(), storage1);
                app.UseHangfireDashboard("/hangfire2", new DashboardOptions(), storage2);
            }
            #endregion
        }
    }
}
