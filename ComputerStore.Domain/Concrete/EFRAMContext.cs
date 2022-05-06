using System.Data.Entity;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class EFRAMContext : DbContext
    {
        public DbSet<RAM> RAMs { get; set; } 
    }
}
