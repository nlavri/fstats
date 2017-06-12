using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FStats.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class StatsViewModel
    {
        public IList<SelectListItem> AllProps { get; set; }

        public string[] FixedProps { get; set; }
    }
}
