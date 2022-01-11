// Alberto Segundo Palencia Benedetty

using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirtsName { get; set; }


        public string LastName { get; set; }
    }
}