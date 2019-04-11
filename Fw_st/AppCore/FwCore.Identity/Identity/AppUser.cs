﻿using Microsoft.AspNetCore.Identity;

namespace FwCore.Identity
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public decimal Bonus { get; set; }
    }//c

}//ns
