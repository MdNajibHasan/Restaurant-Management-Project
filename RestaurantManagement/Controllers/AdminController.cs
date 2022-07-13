using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RestaurantManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public AdminController(AppDbContext context,
                                IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }




        [HttpGet]
        public ViewResult AddMenu()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddMenu(MenuItemModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.PhotoItem != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoItem.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PhotoItem.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                ItemModel itemModel = new ItemModel()
                {
                    MenuId = model.MenuId,
                    MenuItemTitle = model.MenuItemTitle,
                    MenuItemAvailability = model.MenuItemAvailability,
                    MenuItemDescription = model.MenuItemDescription,
                    MenuItemCost = model.MenuItemCost,
                   
                    MenuItemQuantity = model.MenuItemQuantity,
                    PhotoItem = uniqueFileName
                };

                await _context.itemModels.AddAsync(itemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Admin", "Home");

            }
            return View(model);
        }


    }
}








