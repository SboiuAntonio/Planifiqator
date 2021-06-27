using Planifiqator.Data.Entities;
using System.Collections.Generic;

namespace Planifiqator.Data
{
    public interface IAppRepository
    {
        IEnumerable<Destinatie> GetAllDestinatii();
        IEnumerable<Destinatie> GetDestinatiiByNumeDestinatie(string numeDestinatie);
        bool SaveAll();
    }
}