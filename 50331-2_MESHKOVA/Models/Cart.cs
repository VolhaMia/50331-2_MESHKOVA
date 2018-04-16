using _50331_2_MESHKOVA.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _50331_2_MESHKOVA.Models
{
    public class Cart
    {
        List<CartItem> items;
        public Cart()
        {
            items = new List<CartItem>();
        }

        /// <summary>
        /// Добавить в корзину
        /// </summary>
        /// <param name="dish">объект для добавления</param>
        public void AddItem(Dish dish)
        {
            var item = items.Find(i => i.Dish.DishID == dish.DishID);
            if (item == null)
            {
                items.Add(new CartItem { Dish = dish, Quantity = 1 });
            }
            else
                item.Quantity += 1;
        }

        public void RemoveItem(Dish dish)
        {
            var item = items.Find(i => i.Dish.DishID == dish.DishID);
            if (item.Quantity == 1)
                items.Remove(item);
            else
                item.Quantity -= 1;
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        /// <summary>
        /// Получение суммы калорий
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            return items.Sum(i=>i.Dish.Calories*i.Quantity);
        }

        public IEnumerable<CartItem> GetItems()
        {
            return items;
        }
    }
}