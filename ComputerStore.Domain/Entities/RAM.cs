using ComputerStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    public class RAM : Product
    {
        [Display(Name = "Тип памяти")]
        [Required(ErrorMessage = "Введите тип памяти")]
        public string TypeOfMemory { get; set; } // Тип памяти (DDR3)
        [Display(Name = "Объем модуля памяти")]
        [Required(ErrorMessage = "Введите объем модуля памяти")]
        public int Memory { get; set; } // Память
        [Display(Name = "Частота")]
        [Required(ErrorMessage = "Введите частоту")]
        public int Frequency { get; set; } // Частота
    }
}
