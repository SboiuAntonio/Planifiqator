using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Planifiqator.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifiqator.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate del, IOptions<AppSettings> options)
        {
            this._next = del;
            this._appSettings = options.Value;
        }

        public async Task Invoke(HttpContext context, IUtilizatorRepository userRepository)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();

            if (token != null)
                AttachUserToContext(context, userRepository, token);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IUtilizatorRepository userRepository, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("Icanputanystringinhere,becausethekeyisastring,andwillbetreatedasso");
                tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out var securityToken);

                var jwtToken = (JwtSecurityToken)securityToken;
                var userId = int.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "idUser").Value);

                context.Items["User"] = userRepository.FindById(userId);
            }
            catch (Exception)
            {

            }
        }
    }
}
