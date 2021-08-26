using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace RSoft.Lib.Web.Extensions
{

    /// <summary>
    /// Provides extension methods for Health Check
    /// </summary>
    public static class HealthCheckExtension
    {

        /// <summary>
        /// Adds a middleware that provides health check status.
        /// </summary>
        /// <param name="app">Application builder object instance</param>
        public static IApplicationBuilder UseApplicationHealthChecks(this IApplicationBuilder app)
        {

            app
                .UseHealthChecks("/hc", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });


            return app;
        }

    }

}
