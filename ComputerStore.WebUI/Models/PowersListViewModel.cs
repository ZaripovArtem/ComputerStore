using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class PowersListViewModel
    {
        public IEnumerable<Power> Powers { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}