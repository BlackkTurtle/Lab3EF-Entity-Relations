using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string SquadNumber { get; set; }
        public int TeamId { get; set; }
        public int PositionId { get; set; }
        public bool IsInjured { get; set; }
        public virtual Position Position { get; set; } = null!;
        public virtual Teams Teams { get; set; } = null!;
        public virtual ICollection<PlayerStatistics> PlayerStatistics { get; } = new List<PlayerStatistics>();
    }
}
