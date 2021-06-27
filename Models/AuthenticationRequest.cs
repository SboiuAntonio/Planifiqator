using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Models
{
    public class AuthenticationRequest
    {
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
    }
}
