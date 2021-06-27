using Planifiqator.Data.Entities;
using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Services
{
    public interface INotiteService
    {
        bool InsertNotita(AddNotitaRequest request);
        List<Notita> GetAllNotite(GetAllNotiteByUserRequest request);
    }
}
