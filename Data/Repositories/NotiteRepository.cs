using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Repositories
{
    public class NotiteRepository : GenericRepository<Notita>, INotiteRepository
    {
        private readonly DatabaseContext context;
        public NotiteRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }


        public List<Notita> GetAllNotiteById(int UtilizatorId)
        {
            return context.Notite.Where(x => x.Utilizator.Id==UtilizatorId).ToList();
        }
    }
}
