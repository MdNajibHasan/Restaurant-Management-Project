using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
