using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FStats.Models
{
    public class FilterModel
    {
        public FilterModel()
        {
            this.Take = 10;
        }

        public int TotalCount { get; set; }

        public int? Skip { get; set; }

        public int? Take { get; set; }

        public string OrderBy { get; set; }

        public int PageCount => this.Take.HasValue ? (this.TotalCount / this.Take + (this.TotalCount % this.Take == 0 ? 0 : 1)).Value : 0;

        public int CurrentPage => this.Skip.HasValue && this.Take.HasValue ? (this.Skip.Value / this.Take + (this.TotalCount % this.Take < 0 ? 0 : 1)).Value : 1;
    }
}
