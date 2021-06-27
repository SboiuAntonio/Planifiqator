using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Repositories
{
    public class UtilizatorRecompensatRepository : GenericRepository<UtilizatorRecompensat>, IUtilizatorRecompensatRepository {
        private readonly DatabaseContext context;

        public UtilizatorRecompensatRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }
    }
}
