using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _50331_2_MESHKOVA.DAL.Entities
{
    public class Dish
    {
        [HiddenInput]
        public int DishID { get; set; } // id блюда 

        [Required(ErrorMessage ="Введите название")]
        [Display(Name ="Название блюда")]
        public string DishName { get; set; } // название блюда

        [Required(ErrorMessage ="Введите описание")]
        [Display(Name ="Описание")]
        public string Description { get; set; } // описание блюда

        [Required(ErrorMessage ="Введите калорийность продукта")]
        [Range(minimum:7,maximum:1500)]
        [Display(Name ="Калории")]
        public int Calories { get; set; } // кол. калорий на порцию

        [Required(ErrorMessage ="Введите группу блюд")]
        [Display(Name ="Группа")]
        public string GroupName { get; set; } // группа блюд (например, первые блюда, напистки и т.д.)

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; } // данные изображения

        [ScaffoldColumn(false)]
        public string MimeType { get; set; } // Mime - тип данных изображения
    }
}
