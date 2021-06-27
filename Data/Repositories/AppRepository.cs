using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data
{
    public class AppRepository : IAppRepository
    {
        private readonly DatabaseContext context;
        public AppRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<Destinatie> GetAllDestinatii()
        {
            return context.Destinatii.OrderBy(d => d.NumeDestinatie).ToList();
        }
        public IEnumerable<Destinatie> GetDestinatiiByNumeDestinatie(string numeDestinatie)
        {
            return context.Destinatii.Where(d => d.NumeDestinatie == numeDestinatie).ToList();
        }
        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}
