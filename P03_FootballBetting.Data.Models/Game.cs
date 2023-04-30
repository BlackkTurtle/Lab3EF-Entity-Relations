using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }
        public double HomeTeamBetRate { get; set; }
        public double AwayTeamBetRate { get; set; }
        public double DrawBetRate { get; set; }
        public string Result { get; set; }
        public virtual Teams HomeTeam { get; set; } = null!;
        public virtual Teams AwayTeam { get; set; } = null!;
        public virtual ICollection<Bet> Bets { get; } = new List<Bet>();
        public virtual ICollection<PlayerStatistics> PlayerStatistics { get; } = new List<PlayerStatistics>();
    }
}
