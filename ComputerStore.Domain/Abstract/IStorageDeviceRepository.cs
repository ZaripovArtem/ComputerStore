using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
   public interface IStorageDeviceRepository
    {
        IEnumerable<StorageDevice> StorageDevices { get; }
        void SaveChanges(StorageDevice storagedevice);
        StorageDevice DeleteProduct(int Id);
    }
}
