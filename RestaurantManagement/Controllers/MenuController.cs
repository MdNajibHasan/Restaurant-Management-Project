using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.Models;
using RestaurantManagement.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantManagement.Controllers
{
    public class MenuController : Controller
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IItemRepository _itemRepository;
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITableRepository _tableRepository;
        ItemModel itemPlaceOrder;
        public MenuController(IItemRepository itemRepository, AppDbContext context,ITableRepository tableRepository,
                                IHostingEnvironment hostingEnvironment, IOrderStatusRepository orderStatusRepository, UserManager<ApplicationUser> userManager)
        {
            _orderStatusRepository = orderStatusRepository;
            _itemRepository = itemRepository;
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            _tableRepository = tableRepository;
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
        [Authorize]
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
        [Authorize]
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


        [Authorize]
        public IActionResult DeleteItem(int id)
        {
            ItemModel item =  _itemRepository.GetItem(id);
            string act = item.MenuId;
            if (item == null)
            {
                ViewBag.ErrorMessage = $"Item with id = {id} cannot be found";
                return View("Not Found");
            }
            else
            {
                
                _itemRepository.Delete(id);
                return RedirectToAction(act, "Menu");
                
            }

            return RedirectToAction(act, "Menu");
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
        
        public ViewResult PlaceOrder(int id)
        {
            itemPlaceOrder = _itemRepository.GetItem(id);
            return View(itemPlaceOrder);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PlaceOrder(ItemModel model)
        {
           



            /* Using this portion I can get the details of the current logged in user */
            var userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(userId).Result;


            double totalCost = double.Parse(model.MenuItemQuantity.ToString()) * double.Parse(model.MenuItemCost.ToString());



            if (model != null && user!=null)
            {
                DateTime currentTime = DateTime.Now;
                string status = "Order Placed Successfully";

                OrderStatusModel orderStatus = new OrderStatusModel()
                {
                    OrderStatus = status,
                    CreatedDate = currentTime.ToString(),

                    MenuType = model.MenuId,
                    ItemTitle = model.MenuItemTitle,
                    ItemQuantity = model.MenuItemQuantity,
                    PhotoPath = model.PhotoItem,
                    TotalCost = totalCost,

                    UserName = user.UserName,
                    UserId = user.Id,
                    UserAddress = user.Address,
                    UserPhone = user.PhoneNumber

                };
                _orderStatusRepository.Add(orderStatus);
                return RedirectToAction("NewOrders", "Menu");

            }

            return View();
        }


        [HttpGet]
        [Authorize]
        public ViewResult NewOrders()
        {
            var model = _orderStatusRepository.GetAllOrderStatus();
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ViewResult CompletedOrders()
        {
            var model = _orderStatusRepository.GetAllOrderStatus();
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ViewResult UserListNewOrder()
        {
            var model = _orderStatusRepository.GetAllOrderStatus();
            return View(model);
        }


        [HttpGet]
        [Authorize]
        public ViewResult UserListCompletedOrder()
        {
            var model = _orderStatusRepository.GetAllOrderStatus();
            return View(model);
        }



        [HttpGet]
        [Authorize]
        public IActionResult NewOrdersAdmin(string userName)
        {
            var model = _orderStatusRepository.GetAllOrderStatus();
            ViewBag.userName = userName;

            
            return View(model);
        }



        



        [HttpGet]
        [Authorize]
        public IActionResult CompletedOrdersAdmin(string userName)
        {
            var model = _orderStatusRepository.GetAllOrderStatus();
            ViewBag.userName = userName;


            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ViewResult ChangeStatus(int id)
        {
            var model = _orderStatusRepository.GetOrderStatus(id);

            return View(model);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangeStatus(OrderStatusModel model)
        {
            if(model != null)
            {
                _orderStatusRepository.UpdateOrderStatus(model);
                return RedirectToAction("UserListNewOrder", "Menu");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateStatusCompleted(int id)
        {
            var model = _orderStatusRepository.GetOrderStatus(id);
            if (model != null)
            {
                
                model.OrderStatus = "Completed";
                _orderStatusRepository.UpdateOrderStatus(model);
                return RedirectToAction("CompletedOrders", "Menu");
            }
            return View(model);
        }


        [HttpGet]
        public ViewResult TableSelection()
        {
            var model = _tableRepository.GetAllItem();
            return View(model);
        }

        [HttpGet]
        public ViewResult AddNewTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTable(TableViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.PhotoPath != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PhotoPath.CopyTo(new FileStream(filePath, FileMode.Create));
                    
                }



                TableModel table = new TableModel()
                {
                    TableNumber = model.TableNumber,
                    TotalSeat = model.TotalSeat,
                    IsSelected = false,
                    UserName = User.Identity.Name,
                    Date = model.Date,
                    Time = model.Time,
                    PhotoPath = uniqueFileName
                };


                _tableRepository.Add(table);
                return RedirectToAction("TableSelection", "Menu");
            }
            return View(model);
        }



    }
}
