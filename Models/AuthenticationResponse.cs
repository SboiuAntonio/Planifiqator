using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Models
{
    public class AuthenticationResponse
    {
        public int Id { get; set;}
        public string Nume { get; set;}
        public string Email { get; set; }
        public string Parola { get; set; }
        public int Monede { get; set; }
        public string Token { get; set; }
    }
}
