using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Repositories
{
    public class DestinatiiRepository : GenericRepository<Destinatie>, IDestinatiiRepository
    {
        private readonly DatabaseContext context;

        public DestinatiiRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public List<Destinatie> GetAllDestinatii()
        {
            return context.Destinatii.ToList();
        }

        public List<Destinatie> GetAllDestinatiiByOras(string Oras)
        {
            return context.Destinatii.Where(x => x.Oras == Oras).ToList();
        }

        public List<Destinatie> GetAllDestinatiiByRegiune(string Regiune)
        {
            return context.Destinatii.Where(x => x.Regiune == Regiune).ToList();
        }

        public List<Destinatie> GetAllDestinatiiByTara(string Tara)
        {
            return context.Destinatii.Where(x => x.Tara == Tara).ToList();
        }

        public List<Destinatie> GetDestinatieById(int Id)
        {
            return context.Destinatii.Where(x => x.Id == Id).ToList();
        }
    }
}
