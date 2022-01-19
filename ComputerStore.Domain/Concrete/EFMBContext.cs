using ComputerStore.Domain.Entities;
using System.Data.Entity;

namespace ComputerStore.Domain.Concrete
{
    public class EFMBContext : DbContext
    {
        public DbSet<MB> MBs { get; set; }
    }
}
