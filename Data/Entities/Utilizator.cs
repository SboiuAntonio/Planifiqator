using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Entities
{
    public class Utilizator
    {
        public Utilizator()
        {
        }

        public Utilizator(string email, string parola)
        {
            Email = email;
            Parola = parola;
        }

        public Utilizator(string nume, string email, string parola)
        {
            Nume = nume;
            Email = email;
            Parola = parola;
        }

        [Key]
        public int Id { get; set; }

        public string Nume { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; } 
        public int Monede { get; set; }
    }
}
