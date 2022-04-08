using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFGPURepository : IGPURepository
    {
        EFGPUContext context = new EFGPUContext();

        public IEnumerable<GPU> GPUs
        {
            get { return context.GPUs; }
        }
    }
}
