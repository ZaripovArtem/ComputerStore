using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
   public interface ICPURepository
    {
        IEnumerable<CPU> CPUs { get; }
        void SaveChanges(CPU cpu);
        CPU DeleteProduct(int CPUId);
    }
}
