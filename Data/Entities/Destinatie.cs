using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Entities
{
    public class Destinatie
    {
        [Key]
        public int Id { get; set; }

        public string Tara { get; set; }
        public string Regiune { get; set; }
        public string Oras { get; set; }
        public string NumeDestinatie { get; set; }
        public float Rating { get; set; }
        public int NumarRatinguri { get; set; }
       

        public Destinatie()
        {
        }

        public Destinatie(int id, string tara, string regiune, string oras, string numeDestinatie, float rating, int numarRatinguri)
        {
            Id = id;
            Tara = tara;
            Regiune = regiune;
            Oras = oras;
            NumeDestinatie = numeDestinatie;
            Rating = rating;
            NumarRatinguri = numarRatinguri;
        }
    }

}
