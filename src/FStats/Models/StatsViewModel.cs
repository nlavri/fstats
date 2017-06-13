using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FStats.Models
{
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class StatsViewModel : FilterModel
    {
        public List<string> OddsProps { get; set; }

        public List<string> StatsProps { get; set; }

        public List<Statistic> Stats { get; set; }

        public FilterTypeEnum? Filter { get; set; }
    }
}
