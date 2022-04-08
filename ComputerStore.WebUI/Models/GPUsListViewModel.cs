using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class GPUsListViewModel
    {
        public IEnumerable<GPU> GPUs { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}