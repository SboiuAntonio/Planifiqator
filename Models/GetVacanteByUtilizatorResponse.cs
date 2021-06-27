using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Models
{
    public class GetVacanteByUtilizatorResponse
    {
        public int Id { get; set; }
        public string Tara { get; set; }
        public string Regiune { get; set; }
        public string Oras { get; set; }
        public string NumeDestinatie { get; set; }
        public string DataRezervare { get; set; }
    }
}
