using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>(); // общее
        private List<CartLine> lineCollectionMB = new List<CartLine>(); // для материток
        private List<CartLine> lineCollectionCPU = new List<CartLine>(); // для процессоров
        private List<CartLine> lineCollectionGPU = new List<CartLine>(); // для видеокарт
        private List<CartLine> lineCollectionRAM = new List<CartLine>(); // для оперативной памяти
        private List<CartLine> lineCollectionPower = new List<CartLine>(); // для блоков питания
        private List<CartLine> lineCollectionCase = new List<CartLine>(); // для корпусов
        private List<CartLine> lineCollectionFAN = new List<CartLine>(); // для куллеров
        private List<CartLine> lineCollectionStorageDevice = new List<CartLine>(); // для жестких дисков

        public void Update()
        {
            Clear();
            lineCollection.AddRange(lineCollectionCPU);
            lineCollection.AddRange(lineCollectionMB);
            lineCollection.AddRange(lineCollectionGPU);
            lineCollection.AddRange(lineCollectionRAM);
            lineCollection.AddRange(lineCollectionPower);
            lineCollection.AddRange(lineCollectionCase);
            lineCollection.AddRange(lineCollectionFAN);
            lineCollection.AddRange(lineCollectionStorageDevice);
        }

        public void RemoveLine() // используется для сброса корзины
        {
            lineCollectionMB.Clear();
            lineCollectionCPU.Clear();
            lineCollectionGPU.Clear();
            lineCollectionCase.Clear();
            lineCollectionFAN.Clear();
            lineCollectionRAM.Clear();
            lineCollectionPower.Clear();
            lineCollectionStorageDevice.Clear();
            Update();
        }
       
        public decimal ComputeTotalValue() ////////Итого:
        {
            return lineCollection.Sum(e => e.Pprice * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void AddItem(CPU cpu, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionCPU
                .Where(g => g.CPU.Id == cpu.Id)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollectionCPU.Add(new CartLine
                {
                    CPU = cpu,
                    Quantity = quantity,
                    Nname = nname,
                    Pprice = pprice,
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            Update();
        }

        public void AddItemMB(MB mb, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionMB
                .Where(g => g.MB.Id == mb.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollectionMB.Add(new CartLine // добавил MB
                {
                    MB = mb, 
                    Quantity = quantity,
                    Nname = nname,
                    Pprice = pprice
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            Update();
        }

        public void AddItemGPU(GPU gpu, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionGPU
                .Where(g => g.GPU.Id == gpu.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollectionGPU.Add(new CartLine
                {
                    GPU = gpu,
                    Quantity = quantity,
                    Nname = nname,
                    Pprice = pprice
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            Update();
        }

        public void AddItemFAN(FAN fan, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionFAN
                .Where(g => g.FAN.Id == fan.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollectionFAN.Add(new CartLine
                {
                    FAN = fan,
                    Quantity = quantity,
                    Nname = nname,
                    Pprice = pprice
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            Update();
        }

        public void AddItemCase(Case cases, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionCase
                .Where(g => g.Case.Id == cases.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollectionCase.Add(new CartLine
                {
                    Case = cases,
                    Quantity = quantity,
                    Nname = nname,
                    Pprice = pprice
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            Update();
        }

        public void AddItemPower(Power power, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionPower
                .Where(g => g.Power.Id == power.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollectionPower.Add(new CartLine
                {
                    Power = power,
                    Quantity = quantity,
                    Nname = nname,
                    Pprice = pprice
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            Update();
        }

        public void AddItemRAM(RAM ram, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionRAM
                .Where(g => g.RAM.Id == ram.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollectionRAM.Add(new CartLine
                {
                    RAM = ram,
                    Quantity = quantity,
                    Nname = nname,
                    Pprice = pprice
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            Update();
        }

        public void AddItemStorageDevice(StorageDevice sd, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionStorageDevice
                .Where(g => g.StorageDevice.Id == sd.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollectionStorageDevice.Add(new CartLine
                {
                    StorageDevice = sd,
                    Quantity = quantity,
                    Nname = nname,
                    Pprice = pprice
                });
            }
            else
            {
                line.Quantity += quantity;
            }
            Update();
        }
    }

    public class CartLine
    {
        public CPU CPU { get; set; }
        public MB MB { get; set; }
        public GPU GPU { get; set; }
        public RAM RAM { get; set; }
        public Power Power { get; set; }
        public Case Case { get; set; }
        public FAN FAN { get; set; }
        public StorageDevice StorageDevice { get; set; }
        public int Quantity { get; set; }
        public string Nname { get; set; }
        public decimal Pprice { get; set; }
        public int IDCard { get; set; }
    }
}
