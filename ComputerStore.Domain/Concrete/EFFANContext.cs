using System.Data.Entity;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class EFFANContext : DbContext
    {
        public DbSet<FAN> FANs { get; set; } 
    }
}
