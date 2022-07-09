using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    public class AdminController : Controller
    {




        public ViewResult menu()
        {
            return View();
        }

        public ViewResult MenuAdd()
        {
            return View();
        }


        public ViewResult ViewMenu()
        {
            return View();
        }
    }
}
