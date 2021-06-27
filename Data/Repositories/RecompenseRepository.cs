using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Repositories
{
    public class RecompenseRepository : GenericRepository<Recompensa>, IRecompenseRepository
    {

        private readonly DatabaseContext context;

        public RecompenseRepository(DatabaseContext context) : base(context)
            {
                this.context = context;
            }

        public int GetMonedeById(int Id)
        {
            return context.Recompense.Where(x => x.Id == Id).FirstOrDefault().Monede;
        }
    }
}
