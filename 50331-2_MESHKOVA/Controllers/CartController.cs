using _50331_2_MESHKOVA.DAL.Entities;
using _50331_2_MESHKOVA.DAL.Interfaces;
using _50331_2_MESHKOVA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _50331_2_MESHKOVA.Controllers
{
    public class CartController : Controller
    {
        IRepository<Dish> repository;

        public CartController(IRepository<Dish> repo)
        {
            repository = repo;                
        }

        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns></returns>
        /*public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }*/

        // GET: Cart
        [Authorize]
        public ActionResult Index(string returnUrl, Cart cart)
        {
            TempData["returnUrl"] = returnUrl;
            return View(cart);
        }

        public RedirectResult AddToCart(int id, string returnUrl, Cart cart)
        {
            var item = repository.Get(id);
            if (item != null)
                cart.AddItem(item);
            return Redirect(returnUrl);
        }

        public PartialViewResult CartSummary(/*string returnUrl*/ Cart cart)
        {
            //TempData["returnUrl"] = returnUrl;
            return PartialView(cart);
        }
    }
}