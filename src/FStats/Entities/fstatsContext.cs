using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FStats.Entities
{
    public partial class fstatsContext : DbContext
    {
        public virtual DbSet<Statistic> Statistic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(local);Database=fstats;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.Property(e => e.Ac).HasColumnName("AC");

                entity.Property(e => e.Af).HasColumnName("AF");

                entity.Property(e => e.Ar).HasColumnName("AR");

                entity.Property(e => e.As).HasColumnName("AS");

                entity.Property(e => e.Ast).HasColumnName("AST");

                entity.Property(e => e.AwayTeam).HasColumnType("varchar(50)");

                entity.Property(e => e.Ay).HasColumnName("AY");

                entity.Property(e => e.B365a).HasColumnName("B365A");

                entity.Property(e => e.B365d).HasColumnName("B365D");

                entity.Property(e => e.B365h).HasColumnName("B365H");

                entity.Property(e => e.BbAh).HasColumnName("BbAH");

                entity.Property(e => e.BbAhh).HasColumnName("BbAHh");

                entity.Property(e => e.BbAv25).HasColumnName("BbAv<2 5");

                entity.Property(e => e.BbAv251).HasColumnName("BbAv>2 5");

                entity.Property(e => e.BbAvAha).HasColumnName("BbAvAHA");

                entity.Property(e => e.BbAvAhh).HasColumnName("BbAvAHH");

                entity.Property(e => e.BbMx25).HasColumnName("BbMx<2 5");

                entity.Property(e => e.BbMx251).HasColumnName("BbMx>2 5");

                entity.Property(e => e.BbMxAha).HasColumnName("BbMxAHA");

                entity.Property(e => e.BbMxAhh).HasColumnName("BbMxAHH");

                entity.Property(e => e.BbOu).HasColumnName("BbOU");

                entity.Property(e => e.Bwa).HasColumnName("BWA");

                entity.Property(e => e.Bwd).HasColumnName("BWD");

                entity.Property(e => e.Bwh).HasColumnName("BWH");

                entity.Property(e => e.Date).HasColumnType("varchar(50)");

                entity.Property(e => e.Div).HasColumnType("varchar(50)");

                entity.Property(e => e.Ftag).HasColumnName("FTAG");

                entity.Property(e => e.Fthg).HasColumnName("FTHG");

                entity.Property(e => e.Ftr)
                    .HasColumnName("FTR")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hc).HasColumnName("HC");

                entity.Property(e => e.Hf).HasColumnName("HF");

                entity.Property(e => e.HomeTeam).HasColumnType("varchar(50)");

                entity.Property(e => e.Hr).HasColumnName("HR");

                entity.Property(e => e.Hs).HasColumnName("HS");

                entity.Property(e => e.Hst).HasColumnName("HST");

                entity.Property(e => e.Htag).HasColumnName("HTAG");

                entity.Property(e => e.Hthg).HasColumnName("HTHG");

                entity.Property(e => e.Htr)
                    .HasColumnName("HTR")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Hy).HasColumnName("HY");

                entity.Property(e => e.Iwa).HasColumnName("IWA");

                entity.Property(e => e.Iwd).HasColumnName("IWD");

                entity.Property(e => e.Iwh).HasColumnName("IWH");

                entity.Property(e => e.Lba).HasColumnName("LBA");

                entity.Property(e => e.Lbd).HasColumnName("LBD");

                entity.Property(e => e.Lbh).HasColumnName("LBH");

                entity.Property(e => e.Psa).HasColumnName("PSA");

                entity.Property(e => e.Psca).HasColumnName("PSCA");

                entity.Property(e => e.Pscd).HasColumnName("PSCD");

                entity.Property(e => e.Psch).HasColumnName("PSCH");

                entity.Property(e => e.Psd).HasColumnName("PSD");

                entity.Property(e => e.Psh).HasColumnName("PSH");

                entity.Property(e => e.Referee).HasColumnType("varchar(50)");

                entity.Property(e => e.Vca).HasColumnName("VCA");

                entity.Property(e => e.Vcd).HasColumnName("VCD");

                entity.Property(e => e.Vch).HasColumnName("VCH");

                entity.Property(e => e.Wha).HasColumnName("WHA");

                entity.Property(e => e.Whd).HasColumnName("WHD");

                entity.Property(e => e.Whh).HasColumnName("WHH");
            });
        }
    }
}