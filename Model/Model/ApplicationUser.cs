﻿using Microsoft.AspNetCore.Identity;


namespace Model.Model
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
