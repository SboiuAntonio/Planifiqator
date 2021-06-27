using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Repositories
{
    public interface IDestinatiiRepository : IGenericRepository<Destinatie>
    {
        List<Destinatie> GetAllDestinatii();
        List<Destinatie> GetAllDestinatiiByTara(string Tara);
        List<Destinatie> GetAllDestinatiiByRegiune(string Regiune);
        List<Destinatie> GetAllDestinatiiByOras(string Oras);
        List<Destinatie> GetDestinatieById(int Id);
    }
}
