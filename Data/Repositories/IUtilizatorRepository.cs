using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planifiqator.Data.Entities;

namespace Planifiqator.Data
{
    public interface IUtilizatorRepository : IGenericRepository<Utilizator>
    {
        Utilizator GetByNumeAndParola(string Nume, string Parola);
        Utilizator GetMonedeById(int Id);
        Utilizator GetByEmail(string Email);
        Utilizator GetByNume(string Nume);
        List<Utilizator> GetAller();
    }
}

