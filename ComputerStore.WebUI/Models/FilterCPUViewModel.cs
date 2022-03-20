using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using ComputerStore.Domain.Entities;
using System.Web.Mvc;

namespace ComputerStore.WebUI.Models
{
    public class FilterCPUViewModel
    {
        public FilterCPUViewModel(string name)
        {
            SelectedName = name;
        }
        public string SelectedName { get; private set; }
    }
}