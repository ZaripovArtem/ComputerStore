using ComputerStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    public class FAN : Product
    {
        [Display(Name = "Рассеиваемая мощность")]
        [Required(ErrorMessage = "Введите рассеиваемую мощность")]
        public int PowerDissipation { get; set; } // Рассеиваемая мощность
        [Display(Name = "Материал основания")]
        [Required(ErrorMessage = "Введите материал основания")]
        public string BaseMaterial { get; set; } // Материал основания
        [Display(Name = "Материал радиатора")]
        [Required(ErrorMessage = "Введите материал радиатора")]
        public string RadiatorMaterial { get; set; } // Материал радиатора
        [Display(Name = "Скорость вращения")]
        [Required(ErrorMessage = "Введите скорость вращения")]
        public int SpeenSpeed { get; set; } // Скорость вращения
    }
}
