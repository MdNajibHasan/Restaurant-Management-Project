
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                     SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        /*private readonly IUserRepository _userRepository;

        public UserAccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }*/



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }




        [HttpGet]
        
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        
        public async Task<IActionResult> SignUp(RegistrationViewModel model)
        {

            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser()
                {
                    Email = model.Email,
                    Address = model.Address,
                    UserName = model.Username,
                    
                    PhoneNumber = model.Phone
                };
                var result = await userManager.CreateAsync(newUser, model.Password);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }


                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }


            return View(model);
        }


        [HttpGet]
        
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if(result.Succeeded)
                {
                    if(model.Username.ToLower().Contains("najib100"))
                    {
                        return RedirectToAction("Admin", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
               
                ModelState.AddModelError("", "Invalid Login Attempt");

            }


            return View(model);
            //return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public IActionResult UserProfile()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            ApplicationUser user = userManager.FindByIdAsync(userId).Result;

            RegistrationViewModel model = new RegistrationViewModel()
            {
                Username = user.UserName,
                Email = user.Email,
                Address = user.Address,
                Phone = user.PhoneNumber,

            };
            return View(model);
        }



    }
}
