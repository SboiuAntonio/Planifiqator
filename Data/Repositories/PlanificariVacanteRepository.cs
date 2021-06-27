using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Repositories
{
    public class PlanificariVacanteRepository : GenericRepository<PlanificareVacanta>, IPlanificariVacanteRepository
    {
        private readonly DatabaseContext context;

        public PlanificariVacanteRepository(DatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public List<PlanificareVacanta> GetVacanteByUtilizator(int Id)
        {
            return context.PlanificariVacante.Where(x => x.UtilizatorId == Id).ToList();
        }
    }
}
