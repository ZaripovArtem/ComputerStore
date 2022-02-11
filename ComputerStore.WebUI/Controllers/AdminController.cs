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
        
        [HttpPost]
        public ActionResult EditCPU(CPU cpu)
        {
            if (ModelState.IsValid)
            {
                CPURepository.SaveChanges(cpu);
                TempData["message"] = string.Format("Изменения в процессоре \"{0}\" были сохранены", cpu.Name);
                return RedirectToAction("CPU");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(cpu);
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int CPUId)
        {
            CPU deletedProduct = CPURepository.DeleteProduct(CPUId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Процессор \"{0}\" был удален",
                    deletedProduct.Name);
            }
            return RedirectToAction("CPU");
        }

        public ViewResult CreateCPU()
        {
            return View("EditCPU", new CPU());
        }
    }
}
