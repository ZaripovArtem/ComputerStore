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
    public class FANController : Controller
    {
        private IFANRepository repository;

        public FANController(IFANRepository rep)
        {
            repository = rep;
        }

        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc, string name = "", string brand = "")
        {
            IEnumerable<FAN> FANs = repository.FANs;
            int pageSize = 6; // количество товара на 1 странице
            // сортировка
            switch (sortState)
            {
                case SortState.NameDesc:
                    FANs = FANs.OrderByDescending(p => p.Name);
                    break;
                case SortState.PriceAsc:
                    FANs = FANs.OrderBy(p => p.Price);
                    break;
                case SortState.PriceDesc:
                    FANs = FANs.OrderByDescending(p => p.Price);
                    break;
                default:
                    FANs = FANs.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
                    break;
            }

            if (!String.IsNullOrEmpty(brand))
            {
                FANs = FANs.Where(p => p.Brand.Contains(brand));
            }
            if (!String.IsNullOrEmpty(name))
            {
                FANs = FANs.Where(p => p.Name.Contains(name));
            }

            var Brand_Order = new List<string>();
            Brand_Order.Add("");
            int check = 0;
            foreach (var product in FANs)
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

            if (ModelState.IsValid)
            {
                FANsListViewModel model = new FANsListViewModel
                {
                    FANs = FANs,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = repository.FANs.Count()
                    },
                    Name = name,
                    Brand = new SelectList(Brand_Order)
                };
                return View(model);
            }
            else
            return View();
            
        }
        public FileContentResult GetImage(int id)
        {
            FAN fan = repository.FANs
                .FirstOrDefault(c => c.Id == id);
            if (fan != null)
            {
                return File(fan.ImageData, fan.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}