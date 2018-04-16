using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50331_2_MESHKOVA.DAL.Entities
{
    public class FoodContext:DbContext
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">имя строки подключения</param>
        public FoodContext(string name):base(name)
        {
            Database.SetInitializer(new FoodContextInitializer());    
        }

        public DbSet<Dish> Dishes { get; set; }
    }
}
