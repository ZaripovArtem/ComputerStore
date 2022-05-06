using System.Data.Entity;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class EFCaseContext : DbContext
    {
        public DbSet<Case> Cases { get; set; } 
    }
}
