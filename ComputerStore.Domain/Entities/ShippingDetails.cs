using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите Ваше имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите Вашу фамилию")]
        [Display(Name = "Имя")]
        public string Surname { get; set; }
        // Добавить номер телефона

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите улицу")]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Укажите дом")]
        [Display(Name = "Дом")]
        public string House { get; set; }
        [Display(Name = "Квартира")]
        public string Flat { get; set; }
        [Display(Name = "Корпус")]
        public string HouseBuilding { get; set; }  // корпус
        [Display(Name = "Этаж")]
        public string Floor { get; set; } // этаж




    }
}
