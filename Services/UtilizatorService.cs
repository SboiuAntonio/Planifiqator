using Planifiqator.Mapper;
using Planifiqator.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Planifiqator.Data;
using Planifiqator.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Planifiqator.Helpers;

namespace Planifiqator.Services
{
    public class UtilizatorService : IUtilizatorService
    {
        private readonly IUtilizatorRepository _utilizatorRepository;
        private readonly AppSettings _appSettings;
        private DatabaseContext context;

        public UtilizatorService(IUtilizatorRepository userRepository, IOptions<AppSettings> options, DatabaseContext context)
        {
            this._utilizatorRepository = userRepository;
            this._appSettings = options.Value;
            this.context = context;
        }

        public bool Register(AuthenticationRequest request)
        {
            var utilizator = request.ToUtilizatorEntity();
            _utilizatorRepository.Create(utilizator);
            _utilizatorRepository.SaveChanges();
            return true;
        }

        public AuthenticationResponse Login(LoginRequest request)
        {
            if (request == null)
                return null;
            var utilizator = _utilizatorRepository.GetByNumeAndParola(request.Nume, request.Parola);
            if (utilizator == null)
                return null;
            var token = GenerateJwtToken(utilizator);

            return new AuthenticationResponse
            {
                Id = utilizator.Id,
                Nume = utilizator.Nume,
                Email = utilizator.Email,
                Parola = utilizator.Parola,
                Monede = utilizator.Monede,
                Token = token
            };
        }

        public List<Utilizator> GetAll(GetAllUsers request)
        {
            return _utilizatorRepository.GetAller();
        }
        private string GenerateJwtToken(Utilizator utilizator)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Icanputanystringinhere,becausethekeyisastring,andwillbetreatedasso");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("Id", utilizator.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public NumeProfilResponse UpdateNume(NumeProfilRequest request)
        {
            Utilizator utilizator = new Utilizator() {
                Id = Int32.Parse(request.Id),
                Nume = request.Nume
            };
            if (utilizator == null)
                return null;

            var token = GenerateJwtToken(utilizator);
            context.Utilizatori.Attach(utilizator);
            context.Entry(utilizator).Property(x => x.Nume).IsModified = true;
            context.SaveChanges();
            return new NumeProfilResponse
            {
                Id = utilizator.Id,
                Nume = utilizator.Nume,
                Token = token
            };
        }
        public EmailProfilResponse UpdateEmail(EmailProfilRequest request)
        {
            Utilizator utilizator = new Utilizator()
            {
                Id = Int32.Parse(request.Id),
                Email = request.Email
            };
            if (utilizator == null)
                return null;

            var token = GenerateJwtToken(utilizator);
            context.Utilizatori.Attach(utilizator);
            context.Entry(utilizator).Property(x => x.Email).IsModified = true;
            context.SaveChanges();
            return new EmailProfilResponse
            {
                Id = utilizator.Id,
                Email = utilizator.Email,
                Token = token
            };
        }
        public ParolaProfilResponse UpdateParola(ParolaProfilRequest request)
        {
            Utilizator utilizator = new Utilizator()
            {
                Id = Int32.Parse(request.Id),
                Parola = request.Parola
            };
            if (utilizator == null)
                return null;

            var token = GenerateJwtToken(utilizator);
            context.Utilizatori.Attach(utilizator);
            context.Entry(utilizator).Property(x => x.Parola).IsModified = true;
            context.SaveChanges();
            return new ParolaProfilResponse
            {
                Id = utilizator.Id,
                Parola = utilizator.Parola,
                Token = token
            };
        }

        public GetMonedeByIdResponse GetMonedeById(GetMonedeByIdRequest request)
        {
            var utilizator = _utilizatorRepository.GetMonedeById(request.Id);
            if (utilizator == null)
                return null;


            return new GetMonedeByIdResponse
            {
                Id = utilizator.Id,
                Monede = utilizator.Monede
            };
        }

        public Utilizator GetUtilizatorByNume(string Nume)
        {
            return _utilizatorRepository.GetByNume(Nume);
        }

        public Utilizator GetUtilizatorByEmail(string Email)
        {
            return _utilizatorRepository.GetByEmail(Email);
        }
    }
    
}
