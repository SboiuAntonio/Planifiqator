using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Models
{
    public class PutRatingRequest
    {
        public int Id { get; set; }
        public int NumarRatinguri { get; set; }
        public string Rating { get; set; }
    }
}
