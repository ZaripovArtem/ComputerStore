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
    public class PowerController : Controller
    {
        private IPowerRepository repository;

        public PowerController(IPowerRepository rep)
        {
            repository = rep;
        }

        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc, string name = "", string brand = "")
        {
            IEnumerable<Power> Powers = repository.Powers;
            int pageSize = 6; // количество товара на 1 странице
            // сортировка
            switch (sortState)
            {
                case SortState.NameDesc:
                    Powers = Powers.OrderByDescending(p => p.Name);
                    break;
                case SortState.PriceAsc:
                    Powers = Powers.OrderBy(p => p.Price);
                    break;
                case SortState.PriceDesc:
                    Powers = Powers.OrderByDescending(p => p.Price);
                    break;
                default:
                    Powers = Powers.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
                    break;
            }

            if (!String.IsNullOrEmpty(brand))
            {
                Powers = Powers.Where(p => p.Brand.Contains(brand));
            }
            if (!String.IsNullOrEmpty(name))
            {
                Powers = Powers.Where(p => p.Name.Contains(name));
            }

            var Brand_Order = new List<string>();
            Brand_Order.Add("");
            int check = 0;
            foreach (var product in Powers)
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

            PowersListViewModel model = new PowersListViewModel
            {
                Powers = Powers,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Powers.Count()
                },
                Name = name,
                Brand = new SelectList(Brand_Order)
            };

            return View(model);
        }
        public FileContentResult GetImage(int id)
        {
            Power power = repository.Powers
                .FirstOrDefault(c => c.Id == id);
            if (power != null)
            {
                return File(power.ImageData, power.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}