using System.Data.Entity;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class EFPowerContext : DbContext
    {
        public DbSet<Power> Powers { get; set; } 
    }
}
