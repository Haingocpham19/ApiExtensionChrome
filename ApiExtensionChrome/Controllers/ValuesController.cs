using ApiExtensionChrome.ModelEx;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiExtensionChrome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        private IConfiguration _config;
        public ValuesController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("getname")]
        public String GetName()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }
        [HttpPost("getAccountId")]
        public Object GetAccountId()
        {
            var accessToken = Request.Headers["Authorization"];
            var accountId = new ValidateToken(_config).ValidateJwtToken(accessToken);
            return accountId;
        }
    }
}
