using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFRAMRepository : IRAMRepository
    {
        EFRAMContext context = new EFRAMContext();

        public IEnumerable<RAM> RAMs
        {
            get { return context.RAMs; }
        }

        public void SaveChanges(RAM ram)
        {
            if (ram.Id == 0)
                context.RAMs.Add(ram);
            else
            {
                RAM dbEntry = context.RAMs.Find(ram.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = ram.Brand;
                    dbEntry.Name = ram.Name;
                    dbEntry.Description = ram.Description;
                    dbEntry.Price = ram.Price;
                    dbEntry.ImageData = ram.ImageData;
                    dbEntry.ImageMimeType = ram.ImageMimeType;
                    dbEntry.TypeOfMemory = ram.TypeOfMemory;
                    dbEntry.Memory = ram.Memory;
                    dbEntry.Frequency = ram.Frequency;
                }
            }
            context.SaveChanges();
        }
        public RAM DeleteProduct(int Id)
        {
            RAM dbEntry = context.RAMs.Find(Id);
            if (dbEntry != null)
            {
                context.RAMs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
