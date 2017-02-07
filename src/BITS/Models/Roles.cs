using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BITS.Models
{
    public static class Roles
    {

        public static readonly IdentityRole CMG = new IdentityRole() { Name = "CMG", NormalizedName = "CMG" };
        public static readonly IdentityRole Admin = new IdentityRole() { Name = "Admin", NormalizedName = "ADMINISTRATOR" };
        public static readonly IdentityRole User = new IdentityRole() { Name = "User", NormalizedName = "USER" };
        public static readonly IdentityRole Customer = new IdentityRole() { Name = "Customer", NormalizedName = "CUSTOMER" };

        public static IEnumerable<IdentityRole> AllRoles = new List<IdentityRole> {
            CMG,
            Admin,
            User,
            Customer
        };

    }
}
