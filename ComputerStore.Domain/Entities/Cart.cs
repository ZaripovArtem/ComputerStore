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
        

        public void AddItem(CPU cpu, int quantity, string nname, decimal pprice) //// nname
        {
            //CartLine line = lineCollectionCPU  ////////////////////////ошибка тут
            //    .Where(g => g.CPU.CPUId == cpu.CPUId)
            //    .FirstOrDefault();

            //if (line == null)
            //{
            //    lineCollection.Add(new CartLine
            //    {
            //        CPU = cpu,
            //        Quantity = quantity,
            //        Nname = nname, //////////////вся строка
            //        Pprice = pprice,
            //    });
            //}
            //else
            //{
            //    line.Quantity += quantity;
            //}

            CartLine line = lineCollectionCPU
                .Where(g => g.CPU.CPUId == cpu.CPUId)
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
        public void RemoveLine() // CPU cpu
        {
           
            lineCollectionMB.Clear();
            lineCollectionCPU.Clear();
            Update();

        }
       
        public decimal ComputeTotalValue() ////////Итого:
        {
            return lineCollection.Sum(e => e.Pprice * e.Quantity);
            //return lineCollection.Sum(e => e.CPU.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }


        ///////////////////////////////МАТЕРИНСКИЕ ПЛАТЫ/////////////////////////////////////

        public void AddItemMB(MB mb, int quantity, string nname, decimal pprice)
        {
            CartLine line = lineCollectionMB
                .Where(g => g.MB.MBId == mb.MBId)
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

        public void RemoveLineMB(MB mb)
        {
            lineCollection.RemoveAll(l => l.MB.MBId == mb.MBId);
        }

        //public decimal ComputeTotalValueMB()
        //{
        //    return lineCollection.Sum(e => e.MB.Price * e.Quantity);

        //}






        /////////////////////////////////////////////////////////////////////////////////////

        public void Update()
        {
            Clear();
            lineCollection.AddRange(lineCollectionCPU);
            lineCollection.AddRange(lineCollectionMB);
        } 
    }

    public class CartLine
    {
        public CPU CPU { get; set; }
        public MB MB { get; set; }
        public int Quantity { get; set; }
        public string Nname { get; set; }
        public decimal Pprice { get; set; }
        public int IDCard { get; set; }
    }
}
