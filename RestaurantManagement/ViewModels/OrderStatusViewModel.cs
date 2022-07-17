using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.ViewModels
{
    public class OrderStatusViewModel
    {
        
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }
        public string CreatedDate { get; set; }
        public string ItemTitle { get; set; }
        public string MenuType { get; set; }

        public string ItemQuantity { get; set; }
        public double TotalCost { get; set; }

        public string OrderStatus { get; set; }

        public string PhotoPath { get; set; }
    }
}
