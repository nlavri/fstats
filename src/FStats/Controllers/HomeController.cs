using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FStats.Controllers
{
    using Entities;

    public class HomeController : Controller
    {
        private readonly StatsDbContext statsDbContext;

        public HomeController(StatsDbContext statsDbContext)
        {
            this.statsDbContext = statsDbContext;
        }

        public IActionResult Index()
        {
            var stats = this.statsDbContext.Statistic.Take(10).ToList();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
