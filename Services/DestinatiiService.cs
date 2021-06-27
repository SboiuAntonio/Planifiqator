using Microsoft.EntityFrameworkCore;
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
    public class DestinatiiService : IDestinatiiService
    {
        private readonly IDestinatiiRepository _destinatiiRepository;
        private readonly AppSettings _appSettings;
        private DatabaseContext context;

        public DestinatiiService(IDestinatiiRepository destinatiiRepository, IOptions<AppSettings> options, DatabaseContext context)
        {
            this._destinatiiRepository = destinatiiRepository;
            this._appSettings = options.Value;
            this.context = context;
        }

        public List<Destinatie> GetAllDestinatii(AllDestinatiiRequest request)
        {
            return _destinatiiRepository.GetAllDestinatii();
        }

        public List<Destinatie> GetAllDestinatiiByOras(OrasDestinatiiRequest request)
        {
            return _destinatiiRepository.GetAllDestinatiiByOras(request.Oras);
        }

        public List<Destinatie> GetAllDestinatiiByRegiune(RegiuneDestinatiiRequest request)
        {
            return _destinatiiRepository.GetAllDestinatiiByRegiune(request.Regiune);
        }

        public List<Destinatie> GetAllDestinatiiByTara(TaraDestinatiiRequest request)
        {
            return _destinatiiRepository.GetAllDestinatiiByTara(request.Tara);
        }

        public List<Destinatie> GetDestinatieById(int Id)
        {
            return _destinatiiRepository.GetDestinatieById(Id);
        }

        public PutRatingResponse PutRating(PutRatingRequest request)
        {
            var dest = context.Destinatii.Where(x => x.Id == request.Id).FirstOrDefault();


            if (dest == null)
            {
                return null;
            }
            float ratingCurent = dest.Rating;
            int numarRatinguriCurent = dest.NumarRatinguri;

            Destinatie destinatie = new Destinatie()
            {
                Id = request.Id,
                NumarRatinguri = request.NumarRatinguri+1,
                Rating = (ratingCurent*numarRatinguriCurent+float.Parse(request.Rating))/(numarRatinguriCurent+1)
            };

            if (destinatie == null)
            {
                return null;
            }
            context.Entry(dest).State = EntityState.Detached;
            context.Destinatii.Attach(destinatie);
            context.Entry(destinatie).Property(x => x.NumarRatinguri).IsModified = true;
            context.Entry(destinatie).Property(x => x.Rating).IsModified = true;
            context.SaveChanges();
            return new PutRatingResponse
            {
                Id = destinatie.Id,
                Rating = destinatie.Rating,
                NumarRatinguri = destinatie.NumarRatinguri
            };
        }
    }
}
