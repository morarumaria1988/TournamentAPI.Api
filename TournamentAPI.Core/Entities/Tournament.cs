﻿namespace TournamentAPI.Core.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<Game> Games { get; } = new List<Game>();
    }
}
