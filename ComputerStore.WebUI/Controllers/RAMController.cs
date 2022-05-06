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
    public class RAMController : Controller
    {
        private IRAMRepository repository;

        public RAMController(IRAMRepository rep)
        {
            repository = rep;
        }

        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc)
        {
            IEnumerable<RAM> RAMs = repository.RAMs;
            int pageSize = 4; // количество товара на 1 странице
            // сортировка
            switch (sortState)
            {
                case SortState.NameDesc:
                    RAMs = RAMs.OrderByDescending(p => p.Name);
                    break;
                case SortState.PriceAsc:
                    RAMs = RAMs.OrderBy(p => p.Price);
                    break;
                case SortState.PriceDesc:
                    RAMs = RAMs.OrderByDescending(p => p.Price);
                    break;
                default:
                    RAMs = RAMs.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
                    break;
            }

            RAMsListViewModel model = new RAMsListViewModel
            {
                RAMs = RAMs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.RAMs.Count()
                }
            };

            return View(model);
        }
        public FileContentResult GetImage(int id)
        {
            RAM ram = repository.RAMs
                .FirstOrDefault(c => c.Id == id);
            if (ram != null)
            {
                return File(ram.ImageData, ram.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}