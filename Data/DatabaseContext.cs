using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration _config;
        public DatabaseContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Destinatie> Destinatii { get; set; }
        public DbSet<Recompensa> Recompense { get; set; }
        public DbSet<Notita> Notite { get; set; }
        public DbSet<UtilizatorRecompensat> UtilizatoriRecompensati { get; set; }
        public DbSet<PlanificareVacanta> PlanificariVacante { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.EnableSensitiveDataLogging());
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:PlanifiqatorContextDb"]);
       
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notita>().HasOne(n => n.Utilizator).WithMany();
            modelBuilder.Entity<UtilizatorRecompensat>().HasOne(n => n.Utilizator).WithMany();
            modelBuilder.Entity<UtilizatorRecompensat>().HasOne(n => n.Recompensa).WithMany();
            base.OnModelCreating(modelBuilder);

        }*/
    }
}
