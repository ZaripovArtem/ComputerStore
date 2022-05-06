using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
   public interface IFANRepository
    {
        IEnumerable<FAN> FANs { get; }
        void SaveChanges(FAN fan);
        FAN DeleteProduct(int Id);
    }
}
