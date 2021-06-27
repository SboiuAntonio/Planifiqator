using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Models
{
    public class AddNotitaRequest
    {
        public string UtilizatorId { get; set; }
        public string Nume { get; set; }
        public string Continut { get; set; }
    }
}
