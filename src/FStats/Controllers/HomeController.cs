using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FStats.Controllers
{
    using System.Reflection;
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;

    public class HomeController : Controller
    {
        private readonly StatsDbContext statsDbContext;

        private readonly IList<SelectListItem> propertyInfos =
            typeof(Statistic).GetProperties().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Name
            }).ToList();

        private readonly string[] FixedProps = new[]
        {
            nameof(Statistic.Date), nameof(Statistic.HomeTeam), nameof(Statistic.AwayTeam), nameof(Statistic.Fthg),
            nameof(Statistic.Ftag)
        };


        public HomeController(StatsDbContext statsDbContext)
        {
            this.statsDbContext = statsDbContext;
        }

        public IActionResult Index()
        {
            var stats = this.statsDbContext.Statistic.Take(10).ToList();

            var model = new StatsViewModel()
            {
                AllProps = this.propertyInfos,
                FixedProps = this.FixedProps
            };

            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
