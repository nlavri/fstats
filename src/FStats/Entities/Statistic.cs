using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FStats.Entities
{

    public partial class Statistic
    {
        [DisplayName("Contest")]
        public string Div { get; set; }

        [DisplayName("Date")]
        public string Date { get; set; }

        [DisplayName("Home Team")]
        public string HomeTeam { get; set; }

        [DisplayName("Away Team")]
        public string AwayTeam { get; set; }

        [DisplayName("Full Time Home Team Goals")]
        public int? Fthg { get; set; }

        [DisplayName("Full Time Away Team Goals")]
        public int? Ftag { get; set; }

        [DisplayName("Full Time Result(H= Home Win, D= Draw, A= Away Win)")]
        public string Ftr { get; set; }

        [DisplayName("Half Time Home Team Goals")]
        public int? Hthg { get; set; }

        [DisplayName("Half Time Away Team Goals")]
        public int? Htag { get; set; }

        [DisplayName("Half Time Result(H= Home Win, D= Draw, A= Away Win)")]
        public string Htr { get; set; }

        [DisplayName("Match Referee")]
        public string Referee { get; set; }

        [DisplayName("Home Team Shots")]
        public int? Hs { get; set; }

        [DisplayName("Away Team Shots")]
        public int? As { get; set; }

        [DisplayName("Home Team Shots on Target")]
        public int? Hst { get; set; }

        [DisplayName("Away Team Shots on Target")]
        public int? Ast { get; set; }

        [DisplayName("Home Team Fouls Committed")]
        public int? Hf { get; set; }

        [DisplayName("Away Team Fouls Committed")]
        public int? Af { get; set; }

        [DisplayName("Home Team Corners")]
        public int? Hc { get; set; }

        [DisplayName("Away Team Corners")]
        public int? Ac { get; set; }

        [DisplayName("Home Team Yellow Cards")]
        public int? Hy { get; set; }

        [DisplayName("Away Team Yellow Cards")]
        public int? Ay { get; set; }

        [DisplayName("Home Team Red Cards")]
        public int? Hr { get; set; }

        [DisplayName("Away Team Red Cards")]
        public int? Ar { get; set; }



        [DisplayName("Bet365 home win odds")]
        public double? B365h { get; set; }

        [DisplayName("Bet365 draw odds")]
        public double? B365d { get; set; }

        [DisplayName("Bet365 away win odds")]
        public double? B365a { get; set; }


        [DisplayName("Bet & Win home win odds")]
        public double? Bwh { get; set; }

        [DisplayName("Bet & Win draw odds")]
        public double? Bwd { get; set; }

        [DisplayName("Bet & Win away win odds")]
        public double? Bwa { get; set; }


        [DisplayName("Interwetten home win odds")]
        public double? Iwh { get; set; }

        [DisplayName("Interwetten draw odds")]
        public double? Iwd { get; set; }

        [DisplayName("Bet & Win away win odds")]
        public double? Iwa { get; set; }


        [DisplayName("Ladbrokes home win odds")]
        public double? Lbh { get; set; }

        [DisplayName("Ladbrokes draw odds")]
        public double? Lbd { get; set; }

        [DisplayName("Ladbrokes away win odds")]
        public double? Lba { get; set; }


        [DisplayName("Pinnacle home win odds")]
        public double? Psh { get; set; }

        [DisplayName("Pinnacle draw odds")]
        public double? Psd { get; set; }

        [DisplayName("Pinnacle away win odds")]
        public double? Psa { get; set; }


        [DisplayName("William home win odds")]
        public double? Whh { get; set; }

        [DisplayName("William draw odds")]
        public double? Whd { get; set; }

        [DisplayName("William away win odds")]
        public double? Wha { get; set; }


        [DisplayName("VC Bet home win odds")]
        public double? Vch { get; set; }

        [DisplayName("VC Bet draw odds")]
        public double? Vcd { get; set; }

        [DisplayName("VC Bet away win odds")]
        public double? Vca { get; set; }



        [DisplayName("Number of BetBrain bookmakers used to calculate match odds averages and maximums")]
        public double? Bb1X2 { get; set; }

        [DisplayName("Betbrain maximum home win odds")]
        public double? BbMxH { get; set; }

        [DisplayName("Betbrain average home win odds")]
        public double? BbAvH { get; set; }

        [DisplayName("Betbrain maximum draw odds")]
        public double? BbMxD { get; set; }

        [DisplayName("Betbrain average draw win odds")]
        public double? BbAvD { get; set; }

        [DisplayName("Betbrain maximum away win odds")]
        public double? BbMxA { get; set; }

        [DisplayName("Betbrain average away win odds")]
        public double? BbAvA { get; set; }

        [DisplayName("Number of BetBrain bookmakers used to calculate over/under 2.5 goals(total goals) averages and maximums")]
        public double? BbOu { get; set; }

        [DisplayName("Betbrain maximum over 2.5 goals")]
        public double? BbMx251 { get; set; }

        [DisplayName("Betbrain average over 2.5 goals")]
        public double? BbAv251 { get; set; }

        [DisplayName("Betbrain maximum under 2.5 goals")]
        public double? BbMx25 { get; set; }

        [DisplayName("Betbrain average under 2.5 goals")]
        public double? BbAv25 { get; set; }

        [DisplayName("Number of BetBrain bookmakers used to Asian handicap averages and maximums")]
        public double? BbAh { get; set; }

        [DisplayName("Betbrain size of handicap (home team)")]
        public double? BbAhh { get; set; }

        [DisplayName("Betbrain maximum Asian handicap home team odds")]
        public double? BbMxAhh { get; set; }

        [DisplayName("Betbrain average Asian handicap home team odds")]
        public double? BbAvAhh { get; set; }

        [DisplayName("Betbrain maximum Asian handicap away team oddss")]
        public double? BbMxAha { get; set; }

        [DisplayName("Betbrain average Asian handicap away team odds")]
        public double? BbAvAha { get; set; }

        [DisplayName("Pinnacle closing home win odds")]
        public double? Psch { get; set; }

        [DisplayName("Pinnacle closing draw odds")]
        public double? Pscd { get; set; }

        [DisplayName("Pinnacle closing away win odds")]
        public double? Psca { get; set; }

        public int Id { get; set; }
    }
}
