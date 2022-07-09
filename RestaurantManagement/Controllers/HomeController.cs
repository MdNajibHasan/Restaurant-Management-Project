using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Models;
using RestaurantManagement.ViewModels;

namespace RestaurantManagement.Control
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        /*private readonly IUserRepository _userRepository;

public HomeController(IUserRepository userRepository)
{
   _userRepository = userRepository;
}*/




        [HttpGet]      
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Admin()
        {
            return View();
        }

        


    }
}
