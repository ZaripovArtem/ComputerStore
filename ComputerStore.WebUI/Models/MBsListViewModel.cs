using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Models
{
    public class MBsListViewModel
    {
        public IEnumerable<MB> MBs { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public string Name { get; set; }
        public SelectList Brand { get; set; }
    }
}