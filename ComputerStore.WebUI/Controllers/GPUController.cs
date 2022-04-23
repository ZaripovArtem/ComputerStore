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

        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc)
        {
            IEnumerable<GPU> GPUs = repository.GPUs;
            int pageSize = 4; // количество товара на 1 странице
            // сортировка
            switch (sortState)
            {
                case SortState.NameDesc:
                    GPUs = GPUs.OrderByDescending(p => p.Name);
                    break;
                case SortState.PriceAsc:
                    GPUs = GPUs.OrderBy(p => p.Price);
                    break;
                case SortState.PriceDesc:
                    GPUs = GPUs.OrderByDescending(p => p.Price);
                    break;
                default:
                    GPUs = GPUs.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
                    break;
            }

            GPUsListViewModel model = new GPUsListViewModel
            {
                GPUs = GPUs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.GPUs.Count()
                }
            };

            return View(model);
        }
        public FileContentResult GetImage(int id)
        {
            GPU gpu = repository.GPUs
                .FirstOrDefault(c => c.Id == id);
            if (gpu != null)
            {
                return File(gpu.ImageData, gpu.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}