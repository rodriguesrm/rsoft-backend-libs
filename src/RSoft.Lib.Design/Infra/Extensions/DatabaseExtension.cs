using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace RSoft.Lib.Design.Infra.Extensions
{

    /// <summary>
    /// Database extensions
    /// </summary>
    public static class DatabaseExtension
    {

        /// <summary>
        /// Create/Update database by migration tool
        /// </summary>
        /// <param name="app">Application builder object instance</param>
        /// <param name="logger">Logger object</param>
        [ExcludeFromCodeCoverage]
        public static IApplicationBuilder MigrateDatabase<TDbContext>(this IApplicationBuilder app, ILogger logger)
            where TDbContext : DbContext
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using var context = serviceScope.ServiceProvider.GetService<TDbContext>();
                logger.LogInformation($"Migrating database {nameof(TDbContext)}");
                context.Database.Migrate();
                logger.LogInformation($"Database migrated");
            }

            return app;
        }

    }

}
