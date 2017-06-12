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


        private readonly string[] StatsProps = new[]
        {
            nameof(Statistic.Fthg),
            nameof(Statistic.Ftag),
            nameof(Statistic.Ftr),
            nameof(Statistic.Hthg),
            nameof(Statistic.Htag),
            nameof(Statistic.Htr),
            nameof(Statistic.Referee),
            nameof(Statistic.Hs),
            nameof(Statistic.As),
            nameof(Statistic.Hst),
            nameof(Statistic.Ast),
            nameof(Statistic.Hf),
            nameof(Statistic.Af),
            nameof(Statistic.Hc),
            nameof(Statistic.Ac),
            nameof(Statistic.Hy),
            nameof(Statistic.Ay),
            nameof(Statistic.Hr),
            nameof(Statistic.Ar),
        };



        private readonly string[] OddsProps = new[]
        {
            nameof(Statistic.B365h),
            nameof(Statistic.B365d),
            nameof(Statistic.B365a),
            nameof(Statistic.Bwh),
            nameof(Statistic.Bwd),
            nameof(Statistic.Bwa),
            nameof(Statistic.Iwh),
            nameof(Statistic.Iwd),
            nameof(Statistic.Iwa),
            nameof(Statistic.Lbh),
            nameof(Statistic.Lbd),
            nameof(Statistic.Lba),
            nameof(Statistic.Psh),
            nameof(Statistic.Psd),
            nameof(Statistic.Psa),
            nameof(Statistic.Whh),
            nameof(Statistic.Whd),
            nameof(Statistic.Wha),
            nameof(Statistic.Vch),
            nameof(Statistic.Vcd),
            nameof(Statistic.Vca),
            nameof(Statistic.Bb1X2),
            nameof(Statistic.BbMxH),
            nameof(Statistic.BbAvH),
            nameof(Statistic.BbMxD),
            nameof(Statistic.BbAvD),
            nameof(Statistic.BbMxA),
            nameof(Statistic.BbAvA),
            nameof(Statistic.BbOu),
            nameof(Statistic.BbMx251),
            nameof(Statistic.BbAv251),
            nameof(Statistic.BbMx25),
            nameof(Statistic.BbAv25),
            nameof(Statistic.BbAh),
            nameof(Statistic.BbAhh),
            nameof(Statistic.BbMxAhh),
            nameof(Statistic.BbAvAhh),
            nameof(Statistic.BbMxAha),
            nameof(Statistic.BbAvAha),
            nameof(Statistic.Psch),
            nameof(Statistic.Pscd),
            nameof(Statistic.Psca),
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
