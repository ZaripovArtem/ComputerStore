﻿using System;
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


        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc, string name = "", string brand = "")
        {
            IEnumerable<CPU> CPUs = repository.CPUs;
            int pageSize = 4; // количество товара на 1 странице
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
            if (!String.IsNullOrEmpty(brand))
            {
                CPUs = CPUs.Where(p => p.Brand.Contains(brand));
            }
            if (!String.IsNullOrEmpty(name))
            {
                CPUs = CPUs.Where(p => p.Name.Contains(name));
            }

            var Brand_Order = new List<string>();
            Brand_Order.Add("");
            int check = 0; 
            foreach (var product in CPUs)
            {
                foreach(var br_list in Brand_Order)
                {
                    if(br_list == product.Brand)
                    {
                        check++;
                    }
                }
                if(check == 0)
                {
                    Brand_Order.Add(product.Brand);
                }
                check = 0;
            } 

            CPUsListViewModel model = new CPUsListViewModel
            {
                CPUs = CPUs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.CPUs.Count()
                },
                Name = name,
                Brand = new SelectList(Brand_Order)
            };

            return View(model);
        }

        public FileContentResult GetImage(int id)
        {
            CPU cpu = repository.CPUs
                .FirstOrDefault(c => c.Id == id);
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