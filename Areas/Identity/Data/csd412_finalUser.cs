using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace csd412_final.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the csd412_finalUser class
    public class csd412_finalUser : IdentityUser
    {
        [PersonalData]
        public string ? Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
