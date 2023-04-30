using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class Teams
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Initials { get; set; }
        public double Budget { get; set; }
        public int PrimaryKitColorId { get; set; }
        public int SecondaryKitColorId { get; set; }
        public int TownId { get; set; }
        public virtual Town Town { get; set; } = null!;
        public virtual Color SecondaryColors { get; set; } = null!;
        public virtual Color PrimaryColors { get; set; } = null!;
        public virtual ICollection<Player> Players { get; } = new List<Player>();
        public virtual ICollection<Game> AwayGames { get; } = new List<Game>();
        public virtual ICollection<Game> HomeGames { get; } = new List<Game>();
    }
}
