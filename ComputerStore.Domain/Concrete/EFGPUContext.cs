using ComputerStore.Domain.Entities;
using System.Data.Entity;

namespace ComputerStore.Domain.Concrete
{
    public class EFGPUContext : DbContext
    {
        public DbSet<GPU> GPUs { get; set; }
    }
}
