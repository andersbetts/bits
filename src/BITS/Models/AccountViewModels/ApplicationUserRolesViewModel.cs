using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BITS.Models.AccountViewModels
{
    public class ApplicationUserRolesViewModel
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }

    }
}
