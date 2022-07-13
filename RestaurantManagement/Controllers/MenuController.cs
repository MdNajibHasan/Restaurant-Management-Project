using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    public class MenuController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public MenuController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public ViewResult Breakfast()
        {
            var model = _itemRepository.GetAllItem();
            return View(model);
            /*return View();*/
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
