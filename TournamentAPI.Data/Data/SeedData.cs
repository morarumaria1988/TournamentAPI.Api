using Bogus;
using TournamentAPI.Core.Entities;
using TournamentAPI.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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

            var games = GenerateGames(50);
            await context.AddRangeAsync(tournaments);

            await context.SaveChangesAsync(); 


        }

        private static IEnumerable<Game> GenerateGames(int numberOfGames)
        {
            var games = new List<Game>();

            for (int i = 0; i < numberOfGames; i++)
            {
                var title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Company.Bs());
                var time = DateTime.Now;
                var game = new Game { Title = title, Time = time };
                games.Add(game);
            }
            return games; 
        }

        private static IEnumerable<Tournament> GenerateTournaments(int numberOfTournaments)
        {
            var tournaments = new List<Tournament>();

            for (int i = 0; i < numberOfTournaments; i++)
            {
                var avatar = faker.Internet.Avatar();
                var fName = faker.Name.FirstName(); 
                var lName = faker.Name.LastName();
                var email = faker.Internet.Email(fName, lName, "lexicon.se");

                var tournament = new Tournament(avatar, new Name(fName, lName), email)
                {
                    //Avatar = avatar,
                    //FirstName = fName,
                    //LastName = lName,
                    //Email = email,
                    Address = new Address
                    {
                        Street = faker.Address.StreetAddress(),
                        City = faker.Address.City(),
                        ZipCode = faker.Address.ZipCode()
                    }
                };
                tournaments.Add(tournament);
            }

            return tournaments;
        }
    }
}
