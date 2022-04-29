using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    public class StorageDevice
    {
        [Display(Name = "Тип памяти")]
        [Required(ErrorMessage = "Выберите тип памяти")]
        public string Type { get; set; } // Тип - SSD или HDD
        [Display(Name = "Объем накопителя")]
        [Required(ErrorMessage = "Введите объем накопителя")]
        public int Memory { get; set; } // Память
    }
}
