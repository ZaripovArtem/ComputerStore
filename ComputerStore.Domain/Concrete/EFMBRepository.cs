using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.Domain.Concrete
{
    public class EFMBRepository : IMBRepository
    {
        EFMBContext context = new EFMBContext();

        public IEnumerable<MB> MBs
        {
            get { return context.MBs; }
        }
    }
}
