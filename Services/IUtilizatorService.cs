using Planifiqator.Data.Entities;
using Planifiqator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.Services
{
    public interface IUtilizatorService
    {
        bool Register(AuthenticationRequest request);
        AuthenticationResponse Login(LoginRequest request);
        List<Utilizator> GetAll(GetAllUsers request);
        NumeProfilResponse UpdateNume(NumeProfilRequest request);
        EmailProfilResponse UpdateEmail(EmailProfilRequest request);
        ParolaProfilResponse UpdateParola(ParolaProfilRequest request);
        GetMonedeByIdResponse GetMonedeById(GetMonedeByIdRequest request);
        Utilizator GetUtilizatorByNume(String Nume);
        Utilizator GetUtilizatorByEmail(String Email);
    }
}
