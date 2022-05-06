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
    public class CaseController : Controller
    {
        private ICaseRepository repository;

        public CaseController(ICaseRepository rep)
        {
            repository = rep;
        }

        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc)
        {
            IEnumerable<Case> Cases = repository.Cases;
            int pageSize = 4; // количество товара на 1 странице
            // сортировка
            switch (sortState)
            {
                case SortState.NameDesc:
                    Cases = Cases.OrderByDescending(p => p.Name);
                    break;
                case SortState.PriceAsc:
                    Cases = Cases.OrderBy(p => p.Price);
                    break;
                case SortState.PriceDesc:
                    Cases = Cases.OrderByDescending(p => p.Price);
                    break;
                default:
                    Cases = Cases.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
                    break;
            }

            CasesListViewModel model = new CasesListViewModel
            {
                Cases = Cases,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Cases.Count()
                }
            };

            return View(model);
        }
        public FileContentResult GetImage(int id)
        {
            Case Case = repository.Cases
                .FirstOrDefault(c => c.Id == id);
            if (Case != null)
            {
                return File(Case.ImageData, Case.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}