using Microsoft.AspNetCore.Identity;

namespace BestStoreMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirsName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}
