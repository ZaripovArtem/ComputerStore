using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class FANsListViewModel
    {
        public IEnumerable<FAN> FANs { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}