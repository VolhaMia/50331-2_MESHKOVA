using _50331_2_MESHKOVA.DAL.Entities;
using _50331_2_MESHKOVA.DAL.Interfaces;
using _50331_2_MESHKOVA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _50331_2_MESHKOVA.Controllers
{
    public class DishController : Controller
    {
        IRepository<Dish> repository;
        int pageSize = 3;

        public DishController(IRepository<Dish> repo)
        {
            repository = repo;
        }
        // GET: Dish
        public ActionResult List(string group, int page=1)
        {
            var lst = repository.GetAll().Where(d=>group==null||d.GroupName.Equals(group)).OrderBy(d=>d.Calories);
            var model = PageListViewModel<Dish>.CreatePage(lst, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial",model);
            }
            return View(model);
        }

        public async Task<FileResult> GetImage(int productId)
        {
            var dish = await repository.GetAsync(productId);
            if (dish != null)
                return File(dish.Image, dish.MimeType);
            else
                return null;
        }
    }
}