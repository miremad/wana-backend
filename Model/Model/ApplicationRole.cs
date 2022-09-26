using Microsoft.AspNetCore.Identity;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class ApplicationRole: IdentityRole<int>
    {
        public RoleType Type { get; set; }
    }
}
