using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    public class MenuController : Controller
    {
        public ViewResult Breakfast()
        {
            return View();
        }

        public ViewResult Lunch()
        {
            return View();
        }

        public ViewResult Dinner()
        {
            return View();
        }

        public ViewResult Drinks()
        {
            return View();
        }
    }
}
