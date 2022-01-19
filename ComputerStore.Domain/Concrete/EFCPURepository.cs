using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
       public class EFCPURepository : ICPURepository
    {
        EFCPUContext context = new EFCPUContext();

        public IEnumerable<CPU> CPUs
        {
            get { return context.CPUs; }
        }
    }
}
