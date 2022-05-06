using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
   public interface IRAMRepository
    {
        IEnumerable<RAM> RAMs { get; }
        void SaveChanges(RAM ram);
        RAM DeleteProduct(int Id);
    }
}
