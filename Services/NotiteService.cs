using Planifiqator.Mapper;
using Microsoft.Extensions.Options;
using Planifiqator.Data;
using Planifiqator.Data.Entities;
using Planifiqator.Helpers;
using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planifiqator.Data.Repositories;

namespace Planifiqator.Services
{
    public class NotiteService : INotiteService
    {
        private readonly INotiteRepository _notiteRepository;
        private readonly AppSettings _appSettings;
        private DatabaseContext context;

        public NotiteService(INotiteRepository notiteRepository, IOptions<AppSettings> options, DatabaseContext context)
        {
            this._notiteRepository = notiteRepository;
            this._appSettings = options.Value;
            this.context = context;
        }
        public List<Notita> GetAllNotite(GetAllNotiteByUserRequest request)
        {
            return _notiteRepository.GetAllNotiteById(Int16.Parse(request.UtilizatorId));
        }

        public bool InsertNotita(AddNotitaRequest request)
        {
            Notita notita = new Notita()
            {
                UtilizatorId = Int32.Parse(request.UtilizatorId),
                Nume = request.Nume,
                Continut = request.Continut 
            };
            
            if (notita == null)
                return false;

            _notiteRepository.Create(notita);
            _notiteRepository.SaveChanges();
            return true;
        }
    }
}
