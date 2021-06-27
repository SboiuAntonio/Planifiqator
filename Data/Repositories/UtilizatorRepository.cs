using Microsoft.EntityFrameworkCore;
using Planifiqator.Data;
using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data
{
    public class UtilizatorRepository : GenericRepository<Utilizator>, IUtilizatorRepository
    {
        private readonly DatabaseContext context;

        public UtilizatorRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public Utilizator GetByNumeAndParola(string Nume, string Parola)
        {
            return context.Utilizatori.Where(x => x.Nume == Nume && x.Parola == Parola).FirstOrDefault();
        }

        public Utilizator GetMonedeById(int Id)
        {
            return context.Utilizatori.Where(x => x.Id==Id).FirstOrDefault();
        }

        public Utilizator GetByEmail(string Email)
        {
            return context.Utilizatori.Where(x => x.Email == Email).FirstOrDefault();
        }

        public Utilizator GetByNume(string Nume)
        {
            return context.Utilizatori.Where(x => x.Nume == Nume).FirstOrDefault();
        }
        public List<Utilizator> GetAller()
        {
            return context.Utilizatori.OrderByDescending(x => x.Monede).ToList();
        }
    }
}
