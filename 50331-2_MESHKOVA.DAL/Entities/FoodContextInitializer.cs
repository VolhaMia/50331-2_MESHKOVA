﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50331_2_MESHKOVA.DAL.Entities
{
    public class FoodContextInitializer:DropCreateDatabaseIfModelChanges<FoodContext>
    {
        protected override void Seed(FoodContext context)
        {
            List<Dish> dishes = new List<Dish>
            {
                new Dish {DishID=1, DishName="Суп-харчо", Description="Очень острый, невкусный",Calories=200,GroupName="Супы" },
                new Dish {DishID=2, DishName="Борщ", Description="Много сала, без сметаны", Calories=330, GroupName="Супы" },
                new Dish {DishID=3, DishName="Котлета пожарская", Description="Хлеб-80%, Морковь-20%", Calories=635, GroupName="Вторые блюда" },
                new Dish {DishID=4, DishName="Макароны по-флотски", Description="С охотничьей колбаской", Calories=524, GroupName="Вторые блюда" },
                new Dish {DishID=5, DishName="Компот", Description="Быстро растворимый, 2 литра", Calories=180, GroupName="Напитки" }
            };
            context.Dishes.AddRange(dishes);
            context.SaveChanges();
        }
    }
}
