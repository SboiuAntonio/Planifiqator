using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Models
{
    public class PutMonedeToUserRequest
    {
        public int Id { get; set; }
        public int Monede { get; set; }
    }
}
