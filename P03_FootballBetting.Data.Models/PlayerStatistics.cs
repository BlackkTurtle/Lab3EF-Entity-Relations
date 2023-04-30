using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistics
    {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int ScoredGoals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public virtual Game Game { get; set; } = null!;
        public virtual Player Player { get; set; } = null!;
    }
}
