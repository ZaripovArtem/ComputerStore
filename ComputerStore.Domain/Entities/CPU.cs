using ComputerStore.Domain.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ComputerStore.Domain.Entities
{
    public class CPU : Product
    {
        [Display(Name = "Ядра")]
        [Required(ErrorMessage = "Введите кол-во ядер процессора")]
        public int Cores { get; set; } // ядра
        [Display(Name = "Потоки")]
        [Required(ErrorMessage = "Введите кол-во потоков процессора")]
        public int Streams { get; set; } // Потоки
        [Display(Name = "Частота")]
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Введите положительное значение для частоты")]
        public decimal Frequency { get; set; } // частота
    }
}
