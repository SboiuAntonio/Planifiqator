using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Data.Entities
{
    public class Notita
    {
        public Notita()
        {

        }
        public Notita(int id, Utilizator utilizator, string nume, string continut)
        {
            Id = id;
            Utilizator = utilizator;
            Nume = nume;
            Continut = continut;
        }
        [Key]
        public int Id{ get; set; }
        public int UtilizatorId { get; set; }
        [ForeignKey("UtilizatorId")]
        public Utilizator Utilizator { get; set; }
        public string Nume { get; set; }
        public string Continut { get; set; }
        

    }
}
