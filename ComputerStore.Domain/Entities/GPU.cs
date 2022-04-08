using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ComputerStore.Domain.Entities
{
    public class GPU
    {
        [HiddenInput(DisplayValue = false)]
        public int GPUId { get; set; }
        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "Введите производителя процессора")]
        public string Brand { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите название процессора")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание процессора")]
        public string Description { get; set; }
        [Display(Name = "Объем видеопамяти")]
        [Required(ErrorMessage = "Введите объем видеопамяти")]
        public int MemorySize { get; set; } // Объем видеопамяти
        [Display(Name = "Тип памяти")]
        [Required(ErrorMessage = "Введите тип видеопамяти")]
        public string MemoryType { get; set; } // Тип памяти
        [Display(Name = "Пропускная способность памяти на один контакт")]
        [Required(ErrorMessage = "Введите пропускную способность памяти")]
        public int Bandwidth { get; set; } // Пропускная способность памяти на один контакт 
        [Display(Name = "Разрядность шины памяти")]
        [Required(ErrorMessage = "Введите разрядность шины памяти")]
        public int Buswidth { get; set; } // Разрядность шины памяти 
        [Display(Name = "Частота")]
        [Required(ErrorMessage = "Введите частоту")]
        public int Frequency { get; set; } // Частота
        [Display(Name = "Турбо частота")]
        [Required(ErrorMessage = "Введите турбо частоту")]
        public int TurboFrequency { get; set; } // Турбо частота
        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное значение для цены")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

    }
}
