using System.Collections.Generic;
using System.Web.Mvc;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class GPUsListViewModel
    {
        public IEnumerable<GPU> GPUs { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Name { get; set; }
        public SelectList Brand { get; set; }
    }
}