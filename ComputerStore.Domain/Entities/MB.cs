using ComputerStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    // материнские платы
    public class MB : Product
    {
        public string Chipset { get; set; }
        public string Soсket { get; set; }
        public int SATACount { get; set; } // количество портов SATA
        public int SATAECount { get; set; } // количество портов SATA Express
        public int M2Count { get; set; } // количество портов M2Count
        public int USBCount { get; set; } // количество портов USB
        public int PCIEx16Count { get; set; } // количество слотов PCI-E x16
        public int PCIEx4Count { get; set; } // количество слотов PCI-E x4
        public int PCIEx1Count { get; set; } // количество слотов PCI-E x1
        public int PCICount { get; set; } // количество слотов PCI
    }
}
