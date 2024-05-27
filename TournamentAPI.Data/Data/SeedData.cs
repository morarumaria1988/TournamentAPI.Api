using Bogus;
using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Entities;
using TournamentAPI.Data.Data;

namespace LexiconUniversity.Persistance
    {
    public class SeedData
        {

        private static Faker faker;

        public static async Task InitAsync(TournamentAPIApiContext context)
            {
            if (await context.Games.AnyAsync()) return;

            faker = new Faker("sv");

            var tournaments = GenerateTournaments(10);
            await context.AddRangeAsync(tournaments);

            await context.SaveChangesAsync();
            }

        private static IEnumerable<Tournament> GenerateTournaments(int numberOfTournaments)
            {
            var tournaments = new List<Tournament>();

            for (int i = 0; i < numberOfTournaments; i++)
                {
                var tournament = new Tournament
                    {
                    Title = "Tournament 1",
                    StartDate = DateTime.Now.AddDays(7),
                    Games = new List<Game>()
                    {
                    new Game
                    {
                            Title = "Game 1",
                            Time = DateTime.Now.AddDays(7)
                    },
                    new Game
                    {
                            Title = "Game 2",
                            Time = DateTime.Now.AddDays(8)
                    }
                    }
                    };
                tournaments.Add(tournament);
                }
            return tournaments;
            }
        }
    }