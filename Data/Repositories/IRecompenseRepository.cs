using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Repositories
{
    public interface IRecompenseRepository: IGenericRepository<Recompensa>
    {
        int GetMonedeById(int Id);
    }
}
