using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    public class CPU
    {
        public int CPUId { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cores { get; set; } // ядра
        public int Streams { get; set; } // Потоки
        public double Frequency { get; set; } // частота
        public decimal Price { get; set; }

    }
}
