using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
   public interface ICPURepository
    {
        IEnumerable<CPU> CPUs { get; }
        void SaveChanges(CPU cpu);
    }
}
