using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Services
{
    public interface IUtilizatorRecompensatService
    {
        int InsertMonede(AddMonedeRequest request);
    }
}
