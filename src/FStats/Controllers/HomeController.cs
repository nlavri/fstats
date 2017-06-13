using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public static readonly IList<KeyValuePair<FilterTypeEnum, string>> Filters = new List<KeyValuePair<FilterTypeEnum, string>>()
        {
                new KeyValuePair<FilterTypeEnum, string>(FilterTypeEnum.AW, "Away team wins")   ,
            new KeyValuePair<FilterTypeEnum, string>(FilterTypeEnum.HW, "Home team wins"),
            new KeyValuePair<FilterTypeEnum, string>(FilterTypeEnum.AW1, "Away wins by 1 goal"),
            new KeyValuePair<FilterTypeEnum, string>(FilterTypeEnum.HW1, "Home wins by 1 goal"),
            new KeyValuePair<FilterTypeEnum, string>(FilterTypeEnum.AW2, "Away wins by 2 goal"),
            new KeyValuePair<FilterTypeEnum, string>(FilterTypeEnum.HW2, "Home wins by 1 goal")
        };

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

        public async Task<IActionResult> Index(StatsViewModel inModel)
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

            if (inModel.Filter.HasFlag(FilterTypeEnum.AW))
            {
                statsQ = statsQ.Where(x => x.Ftr == "A");
            }
            if (inModel.Filter.HasFlag(FilterTypeEnum.HW))
            {
                statsQ = statsQ.Where(x => x.Ftr == "H");
            }
            if (inModel.Filter.HasFlag(FilterTypeEnum.AW1))
            {
                statsQ = statsQ.Where(x => x.Ftag == x.Fthg + 1);
            }
            if (inModel.Filter.HasFlag(FilterTypeEnum.HW1))
            {
                statsQ = statsQ.Where(x => x.Fthg == x.Ftag + 1);
            }
            if (inModel.Filter.HasFlag(FilterTypeEnum.AW2))
            {
                statsQ = statsQ.Where(x => x.Ftag == x.Fthg + 2);
            }
            if (inModel.Filter.HasFlag(FilterTypeEnum.HW2))
            {
                statsQ = statsQ.Where(x => x.Fthg == x.Ftag + 2);
            }

            var total = statsQ.Count();

            if (inModel.Skip.HasValue)
            {
                statsQ = statsQ.Skip(inModel.Skip.Value);
            }

            if (inModel.Take.HasValue)
            {
                statsQ = statsQ.Take(inModel.Take.Value);
            }

            var stats = statsQ.ToList();
            var model = new StatsViewModel()
            {
                StatsProps = inModel.StatsProps ?? new List<string>() { nameof(Statistic.Fthg), nameof(Statistic.Ftag) },
                OddsProps = inModel.OddsProps ?? new List<string>(),
                Stats = stats,
                TotalCount = total,
                Filter = inModel.Filter,
                Skip = inModel.Skip,
                Take = inModel.Take
            };

            return View(model);
        }


        public IActionResult TeamStats(string name)
        {
            var teamStatsData =
                this.statsDbContext.Statistic.Where(x => x.HomeTeam == name || x.AwayTeam == name)
                    .OrderByDescending(x => x.Date)
                    .Take(10)
                    .ToList();

            var model = new TeamStatsModel()
            {
                Name = name
            };

            model.WinsCount = teamStatsData.Count(
                x =>
                    x.HomeTeam == name
                        ? x.Ftr.Equals("H", StringComparison.OrdinalIgnoreCase)
                        : x.Ftr.Equals("A", StringComparison.OrdinalIgnoreCase));

            model.LooseCount = teamStatsData.Count(
                x =>
                    x.HomeTeam == name
                        ? x.Ftr.Equals("A", StringComparison.OrdinalIgnoreCase)
                        : x.Ftr.Equals("H", StringComparison.OrdinalIgnoreCase));

            model.DrawsCount = teamStatsData.Count(
                x => x.Ftr.Equals("D", StringComparison.OrdinalIgnoreCase));

            model.HomeGoals = teamStatsData.Sum(
                x =>
                    x.HomeTeam == name
                        ? x.Fthg ?? 0
                        : 0);

            model.AwayGoals = teamStatsData.Sum(
                x =>
                    x.HomeTeam == name
                        ? x.Ftag ?? 0
                        : 0);

            model.Games = teamStatsData;

            return PartialView(model);
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
