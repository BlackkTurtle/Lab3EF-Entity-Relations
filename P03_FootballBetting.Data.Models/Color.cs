using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_FootballBetting.Data.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Teams> TeamsSecondary { get; } = new List<Teams>();
        public virtual ICollection<Teams> TeamsPrimary { get; } = new List<Teams>();
    }
}
