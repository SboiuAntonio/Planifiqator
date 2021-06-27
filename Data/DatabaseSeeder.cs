using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Planifiqator.Data
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext databaseContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public DatabaseSeeder(DatabaseContext databaseContext, IWebHostEnvironment webHostEnvironment)
        {
            this.databaseContext = databaseContext;
            this.webHostEnvironment = webHostEnvironment;
        }


        public void Seed()
        {
            databaseContext.Database.EnsureCreated();

            if (!databaseContext.Destinatii.Any())
            {
                var destinatiiJsonFilePath = Path.Combine(webHostEnvironment.ContentRootPath,"Data/Destinatii.json");
                var json = File.ReadAllText(destinatiiJsonFilePath);
                var destinatii = JsonSerializer.Deserialize<IEnumerable<Destinatie>>(json);
                databaseContext.AddRange(destinatii);
                databaseContext.SaveChanges();
            }
            if(!databaseContext.Recompense.Any())
            {
                var recompenseJsonFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Data/Recompense.json");
                var json = File.ReadAllText(recompenseJsonFilePath);
                var recompense = JsonSerializer.Deserialize<IEnumerable<Recompensa>>(json);
                databaseContext.AddRange(recompense);
                databaseContext.SaveChanges();
            }
        }
    }
}
