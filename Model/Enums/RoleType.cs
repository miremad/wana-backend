using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    public enum RoleType : byte
    {
        [Display(Name = "کاربر")]
        User = 1,
    }
}
