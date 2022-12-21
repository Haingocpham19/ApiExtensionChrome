using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiExtensionChrome.Data.Entities
{
    public class AppRole:IdentityRole<Guid>
    {
        public string Decriptions { get; set; }
    }
}
