using ApiExtensionChrome.Application.Catalog;
using ApiExtensionChrome.Data.Models;
using ApiExtensionChrome.ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiExtensionChrome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            //const string user_token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjVGUTh2UTZBWWw4NmdraHFCRGlfVkEiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE2MjkzNTgxNjksImV4cCI6MTYzMTk1MDE2OSwiaXNzIjoiaHR0cHM6Ly9sb2dpbi5zaGlwcXVvY3RlLmNvbSIsImF1ZCI6WyJhaW0tcHJpdmF0ZS1hcGkiLCJjbXMtcHJpdmF0ZS1hcGkiLCJvbS1wcml2YXRlLWFwaSIsImljaGliYS1pZGVudGl0eS1hcGkiLCJhY2MtcHJpdmF0ZS1hcGkiLCJjcy1wcml2YXRlLWFwaSIsIndmLXByaXZhdGUtYXBpIiwid2gtcHJpdmF0ZS1hcGkiLCJzby1wcml2YXRlLWFwaSIsInBvLXByaXZhdGUtYXBpIl0sImNsaWVudF9pZCI6InNvIiwic3ViIjoiZmI4NDkxNjAtNDRiNS00OWQ4LTgwOTMtMDE0N2Y0N2MxOTZlIiwiYXV0aF90aW1lIjoxNjI5Mjc2ODY1LCJpZHAiOiJsb2NhbCIsInJvbGUiOlsiV0hfVk4iLCJXSF9RVCIsIklETSIsIldIX0FETUlOIiwiQURNSU4iLCJBQ0MiLCJBSU0iXSwicHJlZmVycmVkX3VzZXJuYW1lIjoiZHVuZ3BkIiwibmFtZSI6ImR1bmdwZCIsImVtYWlsIjoiZHVuZ3BkQGljaGliYS52biIsInNjb3BlIjpbIm9wZW5pZCIsImVtYWlsIiwicHJvZmlsZSIsImFpbS1wcml2YXRlLWFwaSIsImNtcy1wcml2YXRlLWFwaSIsIm9tLXByaXZhdGUtYXBpIiwiaWNoaWJhLWlkZW50aXR5LWFwaSIsImFjYy1wcml2YXRlLWFwaSIsImNzLXByaXZhdGUtYXBpIiwid2YtcHJpdmF0ZS1hcGkiLCJ3aC1wcml2YXRlLWFwaSIsInNvLXByaXZhdGUtYXBpIiwicG8tcHJpdmF0ZS1hcGkiXSwiYW1yIjpbInB3ZCJdfQ.MzTne7yj9X--psdrp3Kt2TkfxJ5BhRN8NaB-Nxk9975ZrIK9BiEGGIobTzycJMhax13c8c5fE85UJs1t7_zhbU1qTd6u3iUbLPZn4UD28dHRBfQNjoYLHfHpkdUEJuonmL5jUYC9iXAMG-qQG_6aaq6EOjWMVYMDOe72-XbYQMCWt7vptKjXGXG-b9UIV7sG1xIxGn4X50PApG85yrXZbfvf5JFFBj1QqCWNMSic3IL13d4KzFBV82DFUUD8jVQHTht6ImufZnwclFoqlQ5WF4vOiqiJjPoz4qDNc7kCz0kbYr01VK5WhuSCR7lYhdsHD4YeP13RrDLG94-0X_LGjQ";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _userService.Authencate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or Password incorrect");
            }
            return Ok(new { accessToken = resultToken });
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                    return BadRequest(ModelState);
            }
            var result = await _userService.Register(request);
            if (!(result))
            {
                return BadRequest("Register not unsuccesfully.");
            }
            return Ok(new {isSuccessFully = true});
        }
        [HttpGet("TestAuthorize")]
        [Authorize]
        public string TestAuthorize()
        {
            return "authorize is here";
        }
    }
}
