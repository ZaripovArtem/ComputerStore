using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace ComputerStore.Domain.Abstract
{
    public abstract class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "Введите производителя товара")]
        public string Brand { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите название товара")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание товара")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Введите положительное значение для цены")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
