using Planifiqator.Data.Entities;
using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Services
{
    public interface IDestinatiiService
    {
        List<Destinatie> GetAllDestinatii(AllDestinatiiRequest request);
        List<Destinatie> GetAllDestinatiiByTara(TaraDestinatiiRequest request);
        List<Destinatie> GetAllDestinatiiByRegiune(RegiuneDestinatiiRequest request);
        List<Destinatie> GetAllDestinatiiByOras(OrasDestinatiiRequest request);
        List<Destinatie> GetDestinatieById(int id);
        PutRatingResponse PutRating(PutRatingRequest request);
    }
}
