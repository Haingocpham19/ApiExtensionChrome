using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExtensionChrome.ModelEx
{
    public class ValidateToken
    {
        private IConfiguration _config;
        public ValidateToken(IConfiguration config)
        {
            _config = config;
        }
        public int? ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["Tokens:Issuer"],
                    ValidAudience = _config["Tokens:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"])),
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountName = int.Parse(jwtToken.Claims.First(x => x.Type == "name").Value);

                // return account id from JWT token if validation successful
                return accountName;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}
