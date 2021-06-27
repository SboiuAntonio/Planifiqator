using Planifiqator.Data.Entities;
using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Services
{
    public interface IPlanificariVacanteService
    {
        bool InsertPlanificareVacanta(AddVacantaRequest request);
        List<PlanificareVacanta> GetAllVacanteByUtilizator(GetVacanteByUtilizatorRequest request);
    }
}
