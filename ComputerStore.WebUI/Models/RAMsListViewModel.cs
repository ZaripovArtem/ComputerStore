using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class RAMsListViewModel
    {
        public IEnumerable<RAM> RAMs { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}