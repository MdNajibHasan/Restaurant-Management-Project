using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Models;
using RestaurantManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantManagement.Control
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IItemRepository _itemRepository;
        public HomeController(UserManager<ApplicationUser> userManager , IItemRepository itemRepository)
        {
            _userManager = userManager;
            _itemRepository = itemRepository;
        }

        /*private readonly IUserRepository _userRepository;

public HomeController(IUserRepository userRepository)
{
   _userRepository = userRepository;
}*/




        [HttpGet]      
        public IActionResult Index()
        {
            var model = _itemRepository.GetAllItem();


            var userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(userId).Result;

            if(user != null && User.Identity.IsAuthenticated == true)
            {
                if (user.UserName.ToLower().Contains("najib100"))
                {
                    return RedirectToAction("Admin", "Home");
                }
            }

            
            
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }

        


    }
}
