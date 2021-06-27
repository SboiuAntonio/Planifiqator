using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Entities
{
    public class PlanificareVacanta
    {
        public PlanificareVacanta()
        {

        }
        [Key]
        public int Id { get; set; }
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }
        public int DestinatieId { get; set; }
        [ForeignKey("DestinatieId")]
        public Destinatie Destinatie { get; set; }
        public string DataRezervare { get; set; }
    }
}
