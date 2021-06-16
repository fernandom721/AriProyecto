using AriProyecto.Manager;
using AriProyecto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AriProyecto
{
    //URL DE DONDE SAQUE LAS COSAS https://medium.com/@mmoshikoo/jwt-authentication-using-c-54e0c71f21b0

    class Program
    {
        static void Main(string[] args)
        {
            IAuthContainerModel model = (IAuthContainerModel)GetJWTContainerModel("Fernando Martinez", "00076617@uca.edu.sv");
            IAuthService authService = new JWTService(model.SecretKey);

            string token = authService.GenerateToken(model);

            if (!authService.IsTokenValid(token))
                throw new UnauthorizedAccessException();
            else
            {
                List<Claim> claims = authService.GetTokenClaims(token).ToList();

                Console.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Name)).Value);
                Console.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email)).Value);
            }
        }

        #region Private Methods
        private static JWTContainerModel GetJWTContainerModel(string name, string email)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email)
                }
            };
        }
        #endregion
    }
}
