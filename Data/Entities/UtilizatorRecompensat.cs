using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Entities
{
    public class UtilizatorRecompensat
    {
        public UtilizatorRecompensat()
        {

        }
        [Key]
        public int Id { get; set; }
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }
        public int RecompensaId { get; set; }
        [ForeignKey("RecompensaId")]
        public Recompensa Recompensa { get; set; }

        public UtilizatorRecompensat(int id, Utilizator utilizator, Recompensa recompensa)
        {
            Id = id;
            Utilizator = utilizator;
            Recompensa = recompensa;
        }
    }
}
