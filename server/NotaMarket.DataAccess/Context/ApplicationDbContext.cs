using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotaMarket.DataAccess.Identity;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.DataAccess.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-DMGK25P;Database=NotaMarketDb;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=MSI\MSSQLSERVER14;Database=NotaMarketDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrument>()
                   .HasOne(e => e.InstrumentType)
                   .WithMany(c => c.Instruments);

            modelBuilder.Entity<SheetMusic>()
                  .HasOne(e => e.Composer)
                  .WithMany(c => c.SheetMusic);

            modelBuilder.Entity<SheetMusic>()
                  .HasOne(e => e.Instruments)
                  .WithMany(c => c.SheetMusic);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentType> InstrumentTypes { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<SheetMusic> SheetMusics { get; set; }
    }
}
