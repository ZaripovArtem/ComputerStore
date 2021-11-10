using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;

namespace ComputerStore.WebUI.Controllers
{
    public class CPUController : Controller
    {
        private ICPURepository repository;
        public CPUController (ICPURepository rep)
        {
            repository = rep;
        }
        public ViewResult List()
        {
            return View(repository.CPUs);
        }
    }
}