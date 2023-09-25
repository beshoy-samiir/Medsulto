using Microsoft.AspNetCore.Identity;

namespace Eva_project.Models
{
    public class User : IdentityUser
    {
        public string Address { get; set; }
    }
}
