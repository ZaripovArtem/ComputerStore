using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class CasesListViewModel
    {
        public IEnumerable<Case> Cases { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}