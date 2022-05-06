using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
   public interface IPowerRepository
    {
        IEnumerable<Power> Powers { get; }
        void SaveChanges(Power power);
        Power DeleteProduct(int Id);
    }
}
