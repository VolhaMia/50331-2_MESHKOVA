using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _50331_2_MESHKOVA.Models
{
    public class PageListViewModel<T>:List<T>
    {
        /// <summary>
        /// Общее кол-во страниц
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="items">список эл-тов</param>
        /// <param name="total">общее кол-во страниц</param>
        /// <param name="current">номер текущей страницы</param>
        
        private PageListViewModel(List<T> items, int total, int current)
        {
            this.AddRange(items);
            TotalPages = total;
            CurrentPage = current;
        }

        public static PageListViewModel<T> CreatePage(IEnumerable<T> items,int current,int pageSize)
        {
            var totalCount = items.Count();
            var pagesCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            var list = items.Skip(pageSize * (current - 1)).Take(pageSize).ToList();
            return new PageListViewModel<T>(list, pagesCount, current);
        }
    }
}