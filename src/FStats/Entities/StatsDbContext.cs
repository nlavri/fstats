using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FStats.Entities
{
    public class StatsDbContext : DbContext
    {
        public StatsDbContext(DbContextOptions<StatsDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Statistic> Statistic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.Property(e => e.Ac)
                    .HasColumnName("AC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Af)
                    .HasColumnName("AF")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Ar)
                    .HasColumnName("AR")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.As)
                    .HasColumnName("AS")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Ast)
                    .HasColumnName("AST")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AwayTeam).HasColumnType("varchar(50)");

                entity.Property(e => e.Ay)
                    .HasColumnName("AY")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.B365a)
                    .HasColumnName("B365A")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.B365d)
                    .HasColumnName("B365D")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.B365h)
                    .HasColumnName("B365H")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Bb1X2).HasColumnType("varchar(50)");

                entity.Property(e => e.BbAh)
                    .HasColumnName("BbAH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbAhh)
                    .HasColumnName("BbAHh")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbAv25)
                    .HasColumnName("BbAv<2 5")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbAv251)
                    .HasColumnName("BbAv>2 5")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbAvA).HasColumnType("varchar(50)");

                entity.Property(e => e.BbAvAha)
                    .HasColumnName("BbAvAHA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbAvAhh)
                    .HasColumnName("BbAvAHH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbAvD).HasColumnType("varchar(50)");

                entity.Property(e => e.BbAvH).HasColumnType("varchar(50)");

                entity.Property(e => e.BbMx25)
                    .HasColumnName("BbMx<2 5")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbMx251)
                    .HasColumnName("BbMx>2 5")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbMxA).HasColumnType("varchar(50)");

                entity.Property(e => e.BbMxAha)
                    .HasColumnName("BbMxAHA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbMxAhh)
                    .HasColumnName("BbMxAHH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BbMxD).HasColumnType("varchar(50)");

                entity.Property(e => e.BbMxH).HasColumnType("varchar(50)");

                entity.Property(e => e.BbOu)
                    .HasColumnName("BbOU")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Bwa)
                    .HasColumnName("BWA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Bwd)
                    .HasColumnName("BWD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Bwh)
                    .HasColumnName("BWH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Date).HasColumnType("varchar(50)");

                entity.Property(e => e.Div).HasColumnType("varchar(50)");

                entity.Property(e => e.Ftag)
                    .HasColumnName("FTAG")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Fthg)
                    .HasColumnName("FTHG")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Ftr)
                    .HasColumnName("FTR")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hc)
                    .HasColumnName("HC")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hf)
                    .HasColumnName("HF")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.HomeTeam).HasColumnType("varchar(50)");

                entity.Property(e => e.Hr)
                    .HasColumnName("HR")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hs)
                    .HasColumnName("HS")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hst)
                    .HasColumnName("HST")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Htag)
                    .HasColumnName("HTAG")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hthg)
                    .HasColumnName("HTHG")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Htr)
                    .HasColumnName("HTR")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hy)
                    .HasColumnName("HY")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Iwa)
                    .HasColumnName("IWA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Iwd)
                    .HasColumnName("IWD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Iwh)
                    .HasColumnName("IWH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Lba)
                    .HasColumnName("LBA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Lbd)
                    .HasColumnName("LBD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Lbh)
                    .HasColumnName("LBH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Psa)
                    .HasColumnName("PSA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Psca)
                    .HasColumnName("PSCA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Pscd)
                    .HasColumnName("PSCD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Psch)
                    .HasColumnName("PSCH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Psd)
                    .HasColumnName("PSD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Psh)
                    .HasColumnName("PSH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Referee).HasColumnType("varchar(50)");

                entity.Property(e => e.Vca)
                    .HasColumnName("VCA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Vcd)
                    .HasColumnName("VCD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Vch)
                    .HasColumnName("VCH")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Wha)
                    .HasColumnName("WHA")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Whd)
                    .HasColumnName("WHD")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Whh)
                    .HasColumnName("WHH")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}