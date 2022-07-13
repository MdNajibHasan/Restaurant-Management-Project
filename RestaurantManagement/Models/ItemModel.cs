using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
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
        [Required]
        public string PhotoItem { get; set; }
    }
}
