using Microsoft.AspNetCore.Identity;

namespace RestaurantManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
