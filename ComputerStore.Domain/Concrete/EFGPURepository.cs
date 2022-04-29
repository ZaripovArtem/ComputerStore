using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFGPURepository : IGPURepository
    {
        EFGPUContext context = new EFGPUContext();

        public IEnumerable<GPU> GPUs
        {
            get { return context.GPUs; }
        }

        public void SaveChanges(GPU gpu)
        {
            if (gpu.Id == 0)
                context.GPUs.Add(gpu);
            else
            {
                GPU dbEntry = context.GPUs.Find(gpu.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = gpu.Brand;
                    dbEntry.Name = gpu.Name;
                    dbEntry.Description = gpu.Description;
                    dbEntry.Price = gpu.Price;
                    dbEntry.ImageData = gpu.ImageData;
                    dbEntry.ImageMimeType = gpu.ImageMimeType;
                    dbEntry.MemorySize = gpu.MemorySize;
                    dbEntry.MemoryType = gpu.MemoryType;
                    dbEntry.Bandwidth = gpu.Bandwidth;
                    dbEntry.Buswidth = gpu.Buswidth;
                    dbEntry.Frequency = gpu.Frequency;
                    dbEntry.TurboFrequency = gpu.TurboFrequency;
                }
            }
            context.SaveChanges();
        }
        public GPU DeleteProduct(int Id)
        {
            GPU dbEntry = context.GPUs.Find(Id);
            if (dbEntry != null)
            {
                context.GPUs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
