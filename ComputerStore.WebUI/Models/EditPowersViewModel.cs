using ComputerStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerStore.WebUI.Models
{
    public class EditPowersViewModel
    {
        public IEnumerable<Power> Powers { get; set;}
        public string Name { get; set; }
    }
}