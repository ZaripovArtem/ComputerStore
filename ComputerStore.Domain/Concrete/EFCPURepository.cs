using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
       public class EFCPURepository : ICPURepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<CPU> CPUs
        {
            get { return context.CPUs; }
        }
    }
}
