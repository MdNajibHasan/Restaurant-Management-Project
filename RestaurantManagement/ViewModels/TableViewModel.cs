using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.ViewModels
{
    public class TableViewModel
    {
        
        [Required]
        public string TableNumber { get; set; }
        [Required]
        public string TotalSeat { get; set; }
        /*[Required]
        public bool IsSelected { get; set; }
        [Required]
        public string UserName { get; set; }*/
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public IFormFile PhotoPath { get; set; }
    }
}
