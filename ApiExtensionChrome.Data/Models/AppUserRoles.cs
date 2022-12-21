using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiExtensionChrome.Data.Models
{
    public partial class AppUserRoles
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
