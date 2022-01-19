using System.Collections.Generic;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class CPUsListViewModel
    {
        public IEnumerable<CPU> CPUs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}