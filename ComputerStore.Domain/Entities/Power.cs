using ComputerStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    public class Power : Product
    {
        [Display(Name = "Мощность (номинал)")]
        [Required(ErrorMessage = "Введите мощность (номинал)")]
        public int Capacity { get; set; } // Мощность
        [Display(Name = "Разъемы для питания процессора (CPU)")]
        [Required(ErrorMessage = "Введите количество разъемов для питания процессора")]
        public int ConnectorCPU { get; set; } // Разъемы для питания процессора
        [Display(Name = "Разъемы для питания видеокарты (PCI-E)")]
        [Required(ErrorMessage = "Введите количество разъемов для питания видеокарты")]
        public int ConnectorPCIE { get; set; } // Разъемы для питания видеокарты (PCI-E)
        [Display(Name = "Количество разъемов 15-pin SATA")]
        [Required(ErrorMessage = "Введите количество 15-pin SATA")]
        public int CountSATA { get; set; } // Количество 15-pin SATA
        [Display(Name = "Количество разъемов 4-pin Molex")]
        [Required(ErrorMessage = "Введите разъемов количество 4-pin Molex")]
        public int CountMolex { get; set; } // Количество 4-pin Molex
    }
}
