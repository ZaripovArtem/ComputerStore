using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class MBsListViewModel
    {
        public IEnumerable<MB> MBs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}