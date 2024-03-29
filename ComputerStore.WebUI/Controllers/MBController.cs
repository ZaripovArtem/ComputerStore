﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Abstract;
using ComputerStore.WebUI.Models;

namespace ComputerStore.WebUI.Controllers
{
    public class MBController : Controller
    {
        private IMBRepository repository;
        public int pageSize = 4;
        public MBController (IMBRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc, string name = "", string brand = "")
        {
            IEnumerable<MB> MBs = repository.MBs;
            int pageSize = 6; // количество товара на 1 странице
            // сортировка
            switch (sortState)
            {
                case SortState.NameDesc:
                    MBs = MBs.OrderByDescending(p => p.Name);
                    break;
                case SortState.PriceAsc:
                    MBs = MBs.OrderBy(p => p.Price);
                    break;
                case SortState.PriceDesc:
                    MBs = MBs.OrderByDescending(p => p.Price);
                    break;
                default:
                    MBs = MBs.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
                    break;
            }
            if (!String.IsNullOrEmpty(brand))
            {
                MBs = MBs.Where(p => p.Brand.Contains(brand));
            }
            if (!String.IsNullOrEmpty(name))
            {
                MBs = MBs.Where(p => p.Name.Contains(name));
            }

            var Brand_Order = new List<string>();
            Brand_Order.Add("");
            int check = 0;
            foreach (var product in MBs)
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

            MBsListViewModel model = new MBsListViewModel
            {
                MBs = MBs,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.MBs.Count()
                },
                Name = name,
                Brand = new SelectList(Brand_Order)
            };

            return View(model);
        }
        public FileContentResult GetImage(int id)
        {
            MB mb = repository.MBs
                .FirstOrDefault(c => c.Id == id);
            if (mb != null)
            {
                return File(mb.ImageData, mb.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
    
}