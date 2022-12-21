using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApiExtensionChrome.Application.Catalog;
using ApiExtensionChrome.Data.Models;
using ApiExtensionChrome.ViewModel.System.Users;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ApiExtensionChrome.Utilities.Exceptions;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using ApiExtensionChrome.Data.Entities;

namespace ApiExtensionChrome.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roldeManager;
        private readonly IConfiguration _config;
        private readonly OnlineShopContext _context;
        public UserService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<AppRole> roleManager, IConfiguration config, OnlineShopContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roldeManager = roleManager;
            _config = config;
            _context = context;
        }
        public async Task<string> Authencate(LoginRequest request)
        {
            var user = await  _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim("Username", request.UserName),
                new Claim("Email",user.Email),
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName),
                new Claim("Role", string.Join(";",roles)),
                new Claim("DateOfBirth",user.Dob.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                PhoneNumber = request.Phone,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName        
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public List<User> GetAll()
        {
            var query =  _context.User.ToList();      
            return query;
        }
    }
}
