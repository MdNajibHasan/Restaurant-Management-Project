using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Models;

namespace RestaurantManagement.ViewModels
{
    public class HomeDetailsViewModel
    {
        public string Title { get; set; }
        public string PageTitle { get; set; }
        public User User { get; set; }
    }
}
