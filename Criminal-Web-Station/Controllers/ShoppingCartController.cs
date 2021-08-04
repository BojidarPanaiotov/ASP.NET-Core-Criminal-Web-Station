namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Infrastructure;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCartController : Controller
    {
        private readonly IItemService itemService;

        public ShoppingCartController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public IActionResult Index()
        {
            var cart = SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart");

            ViewBag.cart = cart;
            if (cart != null)
            {
                ViewBag.total = cart.Sum(item => item.Price);
            }

            return View();
        }

        public IActionResult Buy(string id)
        {
            List<HomeItemModel> cart;

            if (SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart") == null)
            {
                cart = new List<HomeItemModel>();
            }
            else
            {
                cart = SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart");
            }

            var containsCurrentItem = cart.Any(x => x.Id == id);

            if (containsCurrentItem)
            {
                this.ModelState.AddModelError(string.Empty, "You have already added this item to your shopping cart.");
                return RedirectToAction("Index");
            }

            cart.Add(this.itemService.GetItemByIdGeneric<HomeItemModel>(id));
            SessionExtension.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(string id)
        {
            List<HomeItemModel> cart = SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionExtension.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> cart = SessionExtension.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
