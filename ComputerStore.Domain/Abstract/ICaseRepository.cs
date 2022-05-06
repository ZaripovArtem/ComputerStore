using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
   public interface ICaseRepository
    {
        IEnumerable<Case> Cases { get; }
        void SaveChanges(Case Case);
        Case DeleteProduct(int Id);
    }
}
