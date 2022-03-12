using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;
using ComputerStore.WebUI.Models;

namespace ComputerStore.WebUI.Controllers
{
    public class CPUController : Controller
    {
        private ICPURepository repository;
        public int pageSize = 4;
        public CPUController(ICPURepository rep)
        {
            repository = rep;
        }


        public ViewResult List(int page = 1)
        {
            CPUsListViewModel model = new CPUsListViewModel
            {
                CPUs = repository.CPUs
                    .OrderBy(c => c.CPUId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.CPUs.Count()
                }
            };
            return View(model);
        }

        public FileContentResult GetImage(int cpuid)
        {
            CPU cpu = repository.CPUs
                .FirstOrDefault(c => c.CPUId == cpuid);
            if (cpu != null)
            {
                return File(cpu.ImageData, cpu.ImageMimeType);
            }
            else
            {
                return null;
            }

        }
    }
}