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

        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc, string name = "", string brand = "")
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

            if (!String.IsNullOrEmpty(brand))
            {
                RAMs = RAMs.Where(p => p.Brand.Contains(brand));
            }
            if (!String.IsNullOrEmpty(name))
            {
                RAMs = RAMs.Where(p => p.Name.Contains(name));
            }

            var Brand_Order = new List<string>();
            Brand_Order.Add("");
            int check = 0;
            foreach (var product in RAMs)
            {
                foreach (var br_list in Brand_Order)
                {
                    if (br_list == product.Brand)
                    {
                        check++;
                    }
                }
                if (check == 0)
                {
                    Brand_Order.Add(product.Brand);
                }
                check = 0;
            }

            RAMsListViewModel model = new RAMsListViewModel
            {
                RAMs = RAMs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.RAMs.Count()
                },
                Name = name,
                Brand = new SelectList(Brand_Order)
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