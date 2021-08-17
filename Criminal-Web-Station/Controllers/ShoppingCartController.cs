namespace Criminal_Web_Station.Controllers
{
    using Criminal_Web_Station.Data.Entities;
    using Criminal_Web_Station.Infrastructure;
    using Criminal_Web_Station.Models.Item;
    using Criminal_Web_Station.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCartController : Controller
    {
        private readonly IItemService itemService;
        private readonly IMarketService marketService;
        private readonly ICreditCardService creditCardService;

        public ShoppingCartController(
            IItemService itemService,
            IMarketService marketService,
            ICreditCardService creditCardService)
        {
            this.itemService = itemService;
            this.marketService = marketService;
            this.creditCardService = creditCardService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var cart = SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart");

            this.ViewBag.cart = cart;

            if (cart != null)
            {
                ViewBag.total = cart.Sum(item => item.Price);
            }

            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult AddToCart(string itemId)
        {

            if(this.itemService.DoesThisUserHaveThisItem(this.User.GetId(), itemId))
            {
                this.TempData[WebConstats.Warning] = WebConstats.ItemOwnedMessage;
                return RedirectToAction("Details", "Item", new { itemId });
            }

            List<HomeItemModel> cart;
            if (SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart") == null)
            {
                cart = new List<HomeItemModel>();
            }
            else
            {
                cart = SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart");
            }

            var containsCurrentItem = cart.Any(x => x.Id == itemId);

            if (containsCurrentItem)
            {
                this.TempData[WebConstats.Warning] = WebConstats.ItemHasBeenAddedMessage;
                return RedirectToAction("Details", "Item", new { itemId });
            }

            cart.Add(this.itemService.GetItemByIdGeneric<HomeItemModel>(itemId));
            SessionExtension.SetObjectAsJson(HttpContext.Session, "cart", cart);

            var itemName = this.itemService.GetItemById(itemId).Name;
            this.TempData[WebConstats.Message] = itemName + WebConstats.ItemAddToShoppingCartMessage;

            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult ProcessPayment()
        {
            var accountId = ClaimsPrincipalExtensions.GetId(User);
            //1. Get items in the shopping cart
            var cart = SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart");
            var cartItemsCounts = cart.Count();
            //2. Check if this user have enough money to buy the items
            var totalPrice = cart.Sum(i => i.Price);
            var creditCardBalance = 0.0m;
            if (!this.creditCardService.HasCreditCard(accountId))
            {
                this.TempData[WebConstats.Warning] = WebConstats.NoCreditCardAdded;
                return RedirectToAction("Index", "CreditCard");
            }
            creditCardBalance = this.creditCardService.GetCreditCardBalance(accountId);

            if (totalPrice > creditCardBalance)
            {
                this.TempData[WebConstats.Warning] = WebConstats.NotEnoughMoney;
                return RedirectToAction("Index", "ShoppingCart");
            }

            this.creditCardService.RemoveMoney(accountId, totalPrice);
            //3. Add those item to the user history
            this.marketService.AddToPurchaseHistory(cart, accountId);

            //4. Remove them from the DB
            this.marketService.RemoveItems(cart);

            //5. Remvoe them from shopping cart
            HttpContext.Session.Clear();

            this.TempData[WebConstats.Message] = string.Format(WebConstats.SuccessfulBoughtItems, cartItemsCounts);
            return RedirectToAction("PurchaseHistory", "UserAdds");
        }

        public IActionResult Remove(string id)
        {
            List<HomeItemModel> cart = SessionExtension.GetObjectFromJson<List<HomeItemModel>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionExtension.SetObjectAsJson(HttpContext.Session, "cart", cart);

            var itemName = this.itemService.GetItemById(id).Name;
            this.TempData[WebConstats.Warning] = itemName + WebConstats.ItemRemovedFromShoppingCart;

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
