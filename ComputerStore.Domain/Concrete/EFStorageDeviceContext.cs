using System.Data.Entity;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class EFStorageDeviceContext : DbContext
    {
        public DbSet<StorageDevice> StorageDevices { get; set; } 
    }
}
