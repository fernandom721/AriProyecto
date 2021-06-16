using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace AriProyecto.Model
{
    public class JWTContainerModel
    {

        public int ExpireMinutes { get; set; } = 10080;
        public string SecretKey { get; set; } = "QK8JLkjfp2387tjvl1749fjHHavjltr87hH99y";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public Claim[] Claims { get; set; }
    }
}
