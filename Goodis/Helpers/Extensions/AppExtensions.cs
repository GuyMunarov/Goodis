using Infrastracture.Data;
using Infrastracture.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Goodis.Helpers.Extensions
{
    public static class AppExtensions
    {
        public async static void MigrateDb(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                try
                {
                    dataContext.Database.MigrateAsync();
                    await DataContextSeed.SeedAsync(dataContext, loggerFactory);
                }
                catch (Exception ex)
                {
                    loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "an error in migration");
                }
            }
        }
    }
}
