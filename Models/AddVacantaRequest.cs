using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Models
{
    public class AddVacantaRequest
    {
        public string UtilizatorId { get; set; }
        public int DestinatieId { get; set; }
        public string DataRezervare { get; set; }
    }
}
