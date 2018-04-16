using _50331_2_MESHKOVA.DAL.Entities;
using _50331_2_MESHKOVA.DAL.Interfaces;
using _50331_2_MESHKOVA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace _50331_2_MESHKOVA.Controllers
{
    public class MenuController : Controller
    {
        IRepository<Dish> repository;
        List<MenuItem> items;

        public MenuController(IRepository<Dish> repo)
        {
            repository = repo;
            items = new List<MenuItem>
            {
                new MenuItem {Name="Домой", Controller="Home", Action="Index", Active=string.Empty },
                new MenuItem {Name="Меню", Controller="Dish",Action="List", Active=string.Empty },
                new MenuItem {Name="Администрирование", Controller="Admin", Action="Index", Active=string.Empty }
            };
        }

        public PartialViewResult Main(string a="Index", string c="Home")
        {
            try
            {
                items.First(m => m.Controller == c).Active = "active";
                return PartialView(items);
            }
            catch
            {
                return PartialView(items);
            }
        }

        public PartialViewResult UserInfo()
        {
            if (Request.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                var nick = identity.Claims.Where(c => c.Type == "nick").Select(c => c.Value).SingleOrDefault();
                ViewBag.Nick = nick;
            }           
            
            return PartialView();
        }

        public PartialViewResult Side()
        {
            var groups = repository.GetAll().Select(d => d.GroupName).Distinct();
            return PartialView(groups);
        }

        public PartialViewResult Map()
        {
            return PartialView(items);
        }

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
    }
}