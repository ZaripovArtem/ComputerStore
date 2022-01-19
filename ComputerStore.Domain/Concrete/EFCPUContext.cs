using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class EFCPUContext : DbContext
    {
        public DbSet<CPU> CPUs { get; set; } 
    }

}
