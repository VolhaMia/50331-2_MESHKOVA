using _50331_2_MESHKOVA.DAL.Entities;
using _50331_2_MESHKOVA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50331_2_MESHKOVA.DAL.Repositories
{
    public class EFDishRepository:IRepository<Dish>
    {
        FoodContext context;

        public EFDishRepository(string name)
        {
            context = new FoodContext(name);   
        }

        public void Create(Dish t)
        {
            context.Dishes.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = context.Dishes.Find(id);
            if (item != null)
                context.Dishes.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<Dish> Find(Func<Dish, bool> predicate)
        {
            return context.Dishes.Where(predicate).ToList();
        }

        public Dish Get(int id)
        {
            return context.Dishes.Find(id);
        }

        public IEnumerable<Dish> GetAll()
        {
            return context.Dishes;
        }

        public Task<Dish> GetAsync(int id)
        {
            return context.Dishes.FindAsync(id);
        }

        public void Update(Dish t)
        {
            context.Entry<Dish>(t).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
