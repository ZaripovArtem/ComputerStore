using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.Domain.Entities;

namespace ComputerStore.Domain.Abstract
{
    public interface IMBRepository
    {
        IEnumerable<MB> MBs { get; }
        void SaveChanges(MB mb);
        MB DeleteProduct(int Id);
    }
}
