using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ComputerStore.Domain.Entities
{
    public class CPU
    {
        [HiddenInput(DisplayValue = false)]
        public int CPUId { get; set; }
        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "Введите производителя процессора")]
        public string Brand { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите название процессора")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание процессора")]
        public string Description { get; set; }
        [Display(Name = "Ядра")]
        [Required(ErrorMessage = "Введите кол-во ядер процессора")]
        public int Cores { get; set; } // ядра
        [Display(Name = "Потоки")]
        [Required(ErrorMessage = "Введите кол-во потоков процессора")]
        public int Streams { get; set; } // Потоки
        [Display(Name = "Частота")]
        [Required(ErrorMessage = "Введите частоту процессора")]
        public double Frequency { get; set; } // частота
        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное значение для цены")]
        public decimal Price { get; set; }

    }
}
