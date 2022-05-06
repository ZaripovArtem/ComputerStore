using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFPowerRepository : IPowerRepository
    {
        EFPowerContext context = new EFPowerContext();

        public IEnumerable<Power> Powers
        {
            get { return context.Powers; }
        }

        public void SaveChanges(Power power)
        {
            if (power.Id == 0)
                context.Powers.Add(power);
            else
            {
                Power dbEntry = context.Powers.Find(power.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = power.Brand;
                    dbEntry.Name = power.Name;
                    dbEntry.Description = power.Description;
                    dbEntry.Price = power.Price;
                    dbEntry.ImageData = power.ImageData;
                    dbEntry.ImageMimeType = power.ImageMimeType;
                    dbEntry.Capacity = power.Capacity;
                    dbEntry.ConnectorCPU = power.ConnectorCPU;
                    dbEntry.ConnectorPCIE = power.ConnectorPCIE;
                    dbEntry.CountSATA = power.CountSATA;
                    dbEntry.CountMolex = power.CountMolex;
                }
            }
            context.SaveChanges();
        }
        public Power DeleteProduct(int Id)
        {
            Power dbEntry = context.Powers.Find(Id);
            if (dbEntry != null)
            {
                context.Powers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
