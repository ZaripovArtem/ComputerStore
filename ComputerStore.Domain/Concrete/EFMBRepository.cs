using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFMBRepository : IMBRepository
    {
        EFMBContext context = new EFMBContext();

        public IEnumerable<MB> MBs
        {
            get { return context.MBs; }
        }

        public void SaveChanges(MB mb)
        {
            if (mb.Id == 0)
                context.MBs.Add(mb);
            else
            {
                MB dbEntry = context.MBs.Find(mb.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = mb.Brand;
                    dbEntry.Name = mb.Name;
                    dbEntry.Description = mb.Description;
                    dbEntry.Price = mb.Price;
                    dbEntry.ImageData = mb.ImageData;
                    dbEntry.ImageMimeType = mb.ImageMimeType;
                    dbEntry.Chipset = mb.Chipset;
                    dbEntry.Soсket = mb.Soсket;
                    dbEntry.SATACount = mb.SATACount;
                    dbEntry.SATAECount = mb.SATAECount;
                    dbEntry.M2Count = mb.M2Count;
                    dbEntry.USBCount = mb.USBCount;
                    dbEntry.PCIEx16Count = mb.PCIEx16Count;
                    dbEntry.PCIEx4Count = mb.PCIEx4Count;
                    dbEntry.PCIEx1Count = mb.PCIEx1Count;
                    dbEntry.PCICount = mb.PCICount;
                }
            }
            context.SaveChanges();
        }

        public MB DeleteProduct(int Id)
        {
            MB dbEntry = context.MBs.Find(Id);
            if (dbEntry != null)
            {
                context.MBs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
