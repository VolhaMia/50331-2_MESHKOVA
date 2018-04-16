using _50331_2_MESHKOVA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace _50331_2_MESHKOVA.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Get the Cart from the session
            Cart cart = controllerContext.HttpContext.Session[sessionKey] as Cart;
            //Create the Cart if there wasn't one in the session data
            if (cart==null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            return cart;
        }
    }
}