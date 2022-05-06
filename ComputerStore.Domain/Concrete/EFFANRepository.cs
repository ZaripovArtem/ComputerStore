using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFFANRepository : IFANRepository
    {
        EFFANContext context = new EFFANContext();

        public IEnumerable<FAN> FANs
        {
            get { return context.FANs; }
        }

        public void SaveChanges(FAN fan)
        {
            if (fan.Id == 0)
                context.FANs.Add(fan);
            else
            {
                FAN dbEntry = context.FANs.Find(fan.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = fan.Brand;
                    dbEntry.Name = fan.Name;
                    dbEntry.Description = fan.Description;
                    dbEntry.Price = fan.Price;
                    dbEntry.ImageData = fan.ImageData;
                    dbEntry.ImageMimeType = fan.ImageMimeType;
                    dbEntry.BaseMaterial = fan.BaseMaterial;
                    dbEntry.RadiatorMaterial = fan.RadiatorMaterial;
                    dbEntry.SpeenSpeed = fan.SpeenSpeed;
                    dbEntry.PowerDissipation = fan.PowerDissipation;
                }
            }
            context.SaveChanges();
        }
        public FAN DeleteProduct(int Id)
        {
            FAN dbEntry = context.FANs.Find(Id);
            if (dbEntry != null)
            {
                context.FANs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
