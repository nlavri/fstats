using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FStats.Controllers
{
    using System.ComponentModel;
    using System.Reflection;
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;

    public class HomeController : Controller
    {
        private readonly StatsDbContext statsDbContext;

        public static readonly IList<PropertyInfo> PropertyInfos;

        public static readonly IList<SelectListItem> PropertyInfosSelect;

        public static readonly IList<string> FixedProps;

        public static readonly string[] StatsProps = new[]
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

        public static readonly string[] OddsProps = new[]
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

        static HomeController()
        {
            PropertyInfosSelect = typeof(Statistic).GetProperties().Select(x => new SelectListItem()
            {
                Text = $"{x.Name} - {x.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName}",
                Value = x.Name
            }).ToList();
            PropertyInfos = typeof(Statistic).GetProperties();
            FixedProps = new List<string>
            {
                nameof(Statistic.Date), nameof(Statistic.HomeTeam), nameof(Statistic.AwayTeam), nameof(Statistic.Fthg),
                nameof(Statistic.Ftag)
            };
        }

        public IActionResult Index(StatsViewModel inModel)
        {
            ViewBag.OrderOptions = GetOrderOptions();

            IQueryable<Statistic> statsQ = this.statsDbContext.Statistic;
            switch (inModel.OrderBy)
            {
                case "date":
                    statsQ = statsQ.OrderBy(x => x.Date);
                    break;
                case "home":
                    statsQ = statsQ.OrderBy(x => x.HomeTeam);
                    break;
                case "away":
                    statsQ = statsQ.OrderBy(x => x.AwayTeam);
                    break;

            }

            var stats = statsQ.Take(10).ToList();
            var model = new StatsViewModel()
            {
                StatsProps = inModel.StatsProps ?? new List<string>() { nameof(Statistic.Fthg), nameof(Statistic.Ftag) },
                OddsProps = inModel.OddsProps ?? new List<string>(),
                Stats = stats
            };

            return View(model);
        }

        private IList<SelectListItem> GetOrderOptions()
        {
            return new List<SelectListItem>() {
                    new SelectListItem() { Text = "----", Value = null},
                    new SelectListItem() { Text = "Order by date", Value = "date"},
                    new SelectListItem() { Text = "Order by home team", Value = "home"},
                    new SelectListItem() { Text = "Order by away team", Value = "away"},
                };
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
