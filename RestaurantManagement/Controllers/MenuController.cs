using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RestaurantManagement.Controllers
{
    public class MenuController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public MenuController(IItemRepository itemRepository, AppDbContext context,
                                IHostingEnvironment hostingEnvironment)
        {
            _itemRepository = itemRepository;
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }


        

       





        [HttpGet]
        public ViewResult Breakfast()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
            /*return View();*/
        }

        [HttpGet]
        public ViewResult Lunch()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
        }

        [HttpGet]
        public ViewResult Dinner()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
        }

        [HttpGet]
        public ViewResult Drinks()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
        }




        [HttpGet]
        public ViewResult EditItem(int id)
        {
            ItemModel item = _itemRepository.GetItem(id);
            EditItemViewModel editItemViewModel = new EditItemViewModel
            {
                Id = item.Id,
                MenuId = item.MenuId,
                MenuItemAvailability = item.MenuItemAvailability,
                MenuItemCost = item.MenuItemCost,
                MenuItemDescription = item.MenuItemDescription,
                MenuItemQuantity = item.MenuItemQuantity,
                MenuItemTitle = item.MenuItemTitle,
                PhotoPath = item.PhotoItem
            };
            return View(editItemViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(EditItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                ItemModel item = _itemRepository.GetItem(model.Id);
                item.MenuId = model.MenuId;
                item.MenuItemAvailability = model.MenuItemAvailability;
                item.MenuItemCost = model.MenuItemCost;
                item.MenuItemDescription = model.MenuItemDescription;
                item.MenuItemQuantity = model.MenuItemQuantity;
                item.MenuItemTitle = model.MenuItemTitle;

                string uniqueFileName = null;
                if (model.PhotoItem != null)
                {
                    if (model.PhotoPath != null)
                    {
                        string filePath1 = Path.Combine(hostingEnvironment.WebRootPath,
                            "Images", model.PhotoPath);

                        System.IO.File.Delete(filePath1);
                    }



                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoItem.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PhotoItem.CopyTo(new FileStream(filePath, FileMode.Create));
                    

                    item.PhotoItem = uniqueFileName;
                }
                else
                {
                    item.PhotoItem = model.PhotoPath;
                }
                



                 _itemRepository.UpdateItem(item);
                
                return RedirectToAction(model.MenuId, "Menu");

            }
            return View(model);
        }



        public IActionResult DeleteItem(int id)
        {
            ItemModel item =  _itemRepository.GetItem(id);

            if(item == null)
            {
                ViewBag.ErrorMessage = $"Item with id = {id} cannot be found";
                return View("Not Found");
            }
            else
            {
                string act = item.MenuId;
                _itemRepository.Delete(id);
                return RedirectToAction(act, "Menu");
                
            }

            return View(item);
        }
        


        [HttpGet]
        public ViewResult BreakfastUser()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
        }

        [HttpGet]
        public ViewResult LunchUser()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
        }


        [HttpGet]
        public ViewResult DinnerUser()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
        }



        [HttpGet]
        public ViewResult DrinksUser()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
        }



        [HttpGet]
        public ViewResult AddToCart(int id)
        {
            ItemModel item = _itemRepository.GetItem(id);
            return View(item);
        }


        [HttpGet]
        public ViewResult CartUser()
        {
            return View();
        }


    }
}
