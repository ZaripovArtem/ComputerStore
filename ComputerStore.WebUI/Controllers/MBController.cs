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
    public class MBController : Controller
    {
        private IMBRepository MBRepository;
        public int pageSize = 4;
        public MBController (IMBRepository repo)
        {
            MBRepository = repo;
        }

        public ViewResult List(int page = 1)
        {
            MBsListViewModel model = new MBsListViewModel
            {
                MBs = MBRepository.MBs
                    .OrderBy(mb => mb.MBId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = MBRepository.MBs.Count()
                }
            };
            return View(model);
        }
    }
    
}