﻿using ApiExtensionChrome.Data.Models;
using ApiExtensionChrome.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiExtensionChrome.Application.Catalog
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
        List<User> GetAll();
    }
}
