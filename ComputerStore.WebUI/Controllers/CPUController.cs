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
    public class CPUController : Controller
    {
        private ICPURepository repository;
        public int pageSize = 4;
        public CPUController(ICPURepository rep)
        {
            repository = rep;
        }


        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc)
        {
            IEnumerable<CPU> CPUs = repository.CPUs;
            int pageSize = 2; // количество товара на 1 странице
            // сортировка
            switch (sortState)
            {
                case SortState.NameDesc:
                    CPUs = CPUs.OrderByDescending(p => p.Name);
                    break;
                case SortState.PriceAsc:
                    CPUs = CPUs.OrderBy(p => p.Price);
                    break;
                case SortState.PriceDesc:
                    CPUs = CPUs.OrderByDescending(p => p.Price);
                    break;
                default:
                    CPUs = CPUs.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
                    break;
            }

            CPUsListViewModel model = new CPUsListViewModel
            {
                CPUs = CPUs,
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