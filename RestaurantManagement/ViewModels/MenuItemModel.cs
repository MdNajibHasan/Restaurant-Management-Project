using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.ViewModels
{
    public class MenuItemModel
    {


        
        [Required]
        public string MenuId { get; set; }
        [Required]
        public string MenuItemTitle { get; set; }
        [Required]
        public string MenuItemDescription { get; set; }
        [Required]
        public string MenuItemQuantity { get; set; }
        [Required]
        public double MenuItemCost { get; set; }
        [Required]
        public string MenuItemAvailability { get; set; }
        
        public IFormFile PhotoItem { get; set; }
    }
}
