﻿using TournamentAPI.Data.Data;

namespace TournamentAPI.Api
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<TournamentAPIApiContext>();

                //await context.Database.EnsureDeletedAsync(); TODO
                //await context.Database.MigrateAsync();TODO

                try
                {
                    //await SeedData.InitAsync(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

            }
        }
    }
}

