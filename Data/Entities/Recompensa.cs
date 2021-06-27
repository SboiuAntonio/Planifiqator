using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Entities
{
    public class Recompensa
    {
        [Key]
        public int Id { get; set; }

        public int Monede { get; set; }

        public Recompensa(int id, int monede)
        {
            Id = id;
            Monede = monede;
        }

        public Recompensa()
        {
        }
    }
}
