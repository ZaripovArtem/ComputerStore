﻿using ComputerStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerStore.WebUI.Models
{
    public class EditFANsViewModel
    {
        public IEnumerable<FAN> FANs { get; set;}
        public string Name { get; set; }
    }
}