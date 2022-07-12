﻿using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.ViewModels
{
    public class MenuItemViewModel
    {
        [Required]
        public string MenuItemId { get; set; }
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
        public IFormFile PhotoItem { get; set; }
    }
}
