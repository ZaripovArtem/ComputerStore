using ComputerStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    public class Case : Product
    {
        [Display(Name = "Тип корпуса")]
        [Required(ErrorMessage = "Введите тип корпуса")]
        public string TypeOfCase { get; set; } // Тип корпуса (Mini-Tower)
        [Display(Name = "Длина корпуса")]
        [Required(ErrorMessage = "Введите длину корпуса")]
        public int Length { get; set; } // Длина
        [Display(Name = "Ширина корпуса")]
        [Required(ErrorMessage = "Введите ширину корпуса")]
        public int Width { get; set; } // Ширина
        [Display(Name = "Высота корпуса")]
        [Required(ErrorMessage = "Введите высоту корпуса")]
        public int Height { get; set; } // Высота
        [Display(Name = "Разъемы")]
        [Required(ErrorMessage = "Введите разъемы корпуса")]
        public string Connector { get; set; } // Разъемы
    }
}
