
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

            if (Request.Cookies["userName"] != null)
            {
                Response.Cookies.Delete("userName");
            }


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

                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Append("userName", model.Username, cookieOptions);


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

                        CookieOptions cookieOptions = new CookieOptions();
                        cookieOptions.Expires = DateTime.Now.AddDays(2);
                        Response.Cookies.Append("userName", model.Username, cookieOptions);


                        return RedirectToAction("Admin", "Home");
                    }
                    else
                    {

                        CookieOptions cookieOptions = new CookieOptions();
                        cookieOptions.Expires = DateTime.Now.AddDays(2);
                        Response.Cookies.Append("userName", model.Username, cookieOptions);

                        return RedirectToAction("Index", "Home");
                    }
                }
               
                ModelState.AddModelError("", "Invalid Login Attempt");

            }


            return View(model);
            //return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        [Authorize]
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


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UserProfile(RegistrationViewModel model)
        {
            var userId = userManager.GetUserId(HttpContext.User);
            ApplicationUser user = userManager.FindByIdAsync(userId).Result;

            if(model != null && user != null)
            {
                user.UserName = model.Username;
                user.Address = model.Address;
                user.PhoneNumber = model.Phone;
                user.Email = model.Email;


                await userManager.UpdateAsync(user);

                if(user.UserName.ToLower().Contains("najib100"))
                {
                    return RedirectToAction("Admin", "home");
                }
                else
                {
                    return RedirectToAction("index", "home");
                }
            }

            return View(model);


        }



    }
}
