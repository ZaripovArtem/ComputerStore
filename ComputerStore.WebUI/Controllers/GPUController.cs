using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;
using ComputerStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;


namespace ComputerStore.WebUI.Controllers
{
    public class GPUController : Controller
    {
        private IGPURepository repository;

        public GPUController(IGPURepository rep)
        {
            repository = rep;
        }

        public ActionResult List(int page = 1, SortState sortState = SortState.NameAsc)
        {
            IEnumerable<GPU> GPUs = repository.GPUs;
            int pageSize = 4; // количество товара на 1 странице
                    GPUs = GPUs.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
            return View(repository.GPUs);
        }
    }
}