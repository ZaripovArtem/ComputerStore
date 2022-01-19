using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;

namespace ComputerStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        ICPURepository CPURepository; // CPU
        IMBRepository MBRepository; // MB

        public AdminController (ICPURepository CPUrep, IMBRepository MBrep)
        {
            CPURepository = CPUrep;
            MBRepository = MBrep;
        }
        // GET: Admin
        public ActionResult CPU()
        {
            return View(CPURepository.CPUs);
        }

        public ViewResult EditCPU(int cpuid)
        {
            CPU cpu = CPURepository.CPUs
                .FirstOrDefault(c => c.CPUId == cpuid);
            return View(cpu);
        }
    }
}