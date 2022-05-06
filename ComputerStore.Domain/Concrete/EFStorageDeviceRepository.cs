using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFStorageDeviceRepository : IStorageDeviceRepository
    {
        EFStorageDeviceContext context = new EFStorageDeviceContext();

        public IEnumerable<StorageDevice> StorageDevices
        {
            get { return context.StorageDevices; }
        }

        public void SaveChanges(StorageDevice storagedevice)
        {
            if (storagedevice.Id == 0)
                context.StorageDevices.Add(storagedevice);
            else
            {
                StorageDevice dbEntry = context.StorageDevices.Find(storagedevice.Id);
                if (dbEntry != null)
                {
                    dbEntry.Brand = storagedevice.Brand;
                    dbEntry.Name = storagedevice.Name;
                    dbEntry.Description = storagedevice.Description;
                    dbEntry.Price = storagedevice.Price;
                    dbEntry.ImageData = storagedevice.ImageData;
                    dbEntry.ImageMimeType = storagedevice.ImageMimeType;
                    dbEntry.Type = storagedevice.Type;
                    dbEntry.Memory = storagedevice.Memory;
                }
            }
            context.SaveChanges();
        }
        public StorageDevice DeleteProduct(int Id)
        {
            StorageDevice dbEntry = context.StorageDevices.Find(Id);
            if (dbEntry != null)
            {
                context.StorageDevices.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
