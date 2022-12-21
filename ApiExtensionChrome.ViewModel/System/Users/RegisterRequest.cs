using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.ViewModel.System.Users
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { set; get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { set; get; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
