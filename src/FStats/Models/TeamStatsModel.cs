using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FStats.Entities;

namespace FStats.Models
{
    public class TeamStatsModel
    {
        public string Name { get; set; }

        public string HomeWins { get; set; }

        public string AwayWins { get; set; }

        public int WinsCount { get; set; }

        public int LooseCount { get; set; }

        public int DrawsCount { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public List<Statistic> Games { get; set; }
    }
}
