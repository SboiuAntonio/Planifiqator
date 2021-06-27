using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Repositories
{
    public interface INotiteRepository : IGenericRepository<Notita>
    {
        List<Notita> GetAllNotiteById(int UtilizatorId);
    }
}
