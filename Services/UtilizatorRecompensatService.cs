using Microsoft.EntityFrameworkCore;
using Planifiqator.Data;
using Planifiqator.Data.Entities;
using Planifiqator.Data.Repositories;
using Planifiqator.Helpers;
using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Planifiqator.Services
{
    public class UtilizatorRecompensatService : IUtilizatorRecompensatService
    {
        private IUtilizatorRecompensatRepository _utilizatorRecompensatRepository;
        private IUtilizatorRepository _utilizatorRepository;
        private IRecompenseRepository _recompenseRepository;
        private readonly AppSettings _appSettings;
        private DatabaseContext context;

        public UtilizatorRecompensatService(IUtilizatorRecompensatRepository utilizatorRecompensatRepository, IOptions<AppSettings> appSettings, DatabaseContext context)
        {
            _utilizatorRecompensatRepository = utilizatorRecompensatRepository;
            this._appSettings = appSettings.Value;
            this.context = context;
        }

        public int InsertMonede(AddMonedeRequest request)
        {
            UtilizatorRecompensat utilizatorRecompensat = new UtilizatorRecompensat()
            {
                UtilizatorId = Int32.Parse(request.UtilizatorId),
                RecompensaId = request.RecompensaId,
            };

            if (utilizatorRecompensat == null)
                return 0;

            _utilizatorRecompensatRepository.Create(utilizatorRecompensat);
            _utilizatorRecompensatRepository.SaveChanges();

            

            Utilizator Utilizator =  context.Utilizatori.Where(x => x.Id == Int32.Parse(request.UtilizatorId)).FirstOrDefault();
            Recompensa Recompensa =  context.Recompense.Where(x => x.Id == request.RecompensaId).FirstOrDefault();

            Utilizator utilizator = new Utilizator()
            {
                Id = Int32.Parse(request.UtilizatorId),
                Monede = Utilizator.Monede + Recompensa.Monede
            };

            if (utilizator == null)
            {
                return 0;
            }

            context.Entry(Utilizator).State = EntityState.Detached;
            context.Entry(Recompensa).State = EntityState.Detached;
            context.Entry(utilizatorRecompensat).State = EntityState.Detached;
            context.Utilizatori.Attach(utilizator);
            context.Entry(utilizator).Property(x => x.Monede).IsModified = true;
            context.SaveChanges();
            return utilizator.Monede;
        }
    }
}
