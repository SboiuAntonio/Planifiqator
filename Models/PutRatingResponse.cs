using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Models
{
    public class PutRatingResponse
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public int NumarRatinguri { get; set; }
    }
}
