using Microsoft.Extensions.Options;
using Planifiqator.Data;
using Planifiqator.Data.Entities;
using Planifiqator.Data.Repositories;
using Planifiqator.Helpers;
using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Services
{
    public class PlanificariVacanteService : IPlanificariVacanteService
    {
        private readonly IPlanificariVacanteRepository _planificariVacanteRepository;
        private readonly AppSettings _appSettings;
        private DatabaseContext context;

        public PlanificariVacanteService(IPlanificariVacanteRepository planificariVacanteRepository, IOptions<AppSettings> options, DatabaseContext context)
        {
            this._planificariVacanteRepository = planificariVacanteRepository;
            this._appSettings = options.Value;
            this.context = context;
        }
        public List<PlanificareVacanta> GetAllVacanteByUtilizator(GetVacanteByUtilizatorRequest request)
        {
            return _planificariVacanteRepository.GetVacanteByUtilizator(Int32.Parse(request.UtilizatorId));
        }

        public bool InsertPlanificareVacanta(AddVacantaRequest request)
        {
            PlanificareVacanta planificareVacanta = new PlanificareVacanta()
            {
                UtilizatorId = Int32.Parse(request.UtilizatorId),
                DestinatieId = request.DestinatieId,
                DataRezervare = request.DataRezervare
            };

            if (planificareVacanta == null)
                return false;

            _planificariVacanteRepository.Create(planificareVacanta);
            _planificariVacanteRepository.SaveChanges();
            return true;
        }
    }
}
