using Planifiqator.Data.Entities;
using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Mapper
{
    public static class UtilizatorMapper
    {
        public static Utilizator FromAuthenticationModel(AuthenticationRequest request)
        {
            return new Utilizator
            {
                Email = request.Email,
                Parola = request.Parola
            };
        }
        public static Utilizator ToUtilizatorEntity(this AuthenticationRequest request)
        {
            return new Utilizator
            {
                Nume = request.Nume,
                Email = request.Email,
                Parola = request.Parola
            };
        }
    }
}
