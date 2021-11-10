using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<CPU> CPUs { get; set; }
        // сюда добавим потом оперативку и тд и тп
    }

}
