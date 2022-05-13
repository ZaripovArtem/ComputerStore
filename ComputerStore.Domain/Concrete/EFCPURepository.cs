using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
       public class EFCPURepository : ICPURepository
    {
        EFCPUContext context = new EFCPUContext();

        public IEnumerable<CPU> CPUs
        {
            get { return context.CPUs; }
        }
        public void SaveChanges(CPU cpu)
        {
            if (cpu.Id == 0)
                context.CPUs.Add(cpu);
            else
            {
                CPU dbEntry = context.CPUs.Find(cpu.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = cpu.Brand;
                    dbEntry.Name = cpu.Name;
                    dbEntry.Description = cpu.Description;
                    dbEntry.Cores = cpu.Cores;
                    dbEntry.Streams = cpu.Streams;
                    dbEntry.Frequency = cpu.Frequency;
                    dbEntry.Price = cpu.Price;
                    dbEntry.ImageData = cpu.ImageData; // 
                    dbEntry.ImageMimeType = cpu.ImageMimeType; //
                }
            }
            context.SaveChanges();
        }
        public CPU DeleteProduct(int Id)
        {
            CPU dbEntry = context.CPUs.Find(Id);
            if (dbEntry != null)
            {
                context.CPUs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
