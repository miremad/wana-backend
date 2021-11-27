using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
