using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;
using ComputerStore.WebUI.Models;

namespace ComputerStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ICPURepository CPURepository; // CPU
        IMBRepository MBRepository; // MB
        IGPURepository GPURepository; // GPU

        public AdminController (ICPURepository CPUrep, IMBRepository MBrep, IGPURepository GPUrep)
        {
            CPURepository = CPUrep;
            MBRepository = MBrep;
            GPURepository = GPUrep;
        }
        // GET: Admin
        public ActionResult CPU(string name)
        {
            // return View(CPURepository.CPUs);
            IEnumerable<CPU> CPUs = CPURepository.CPUs;
            if (!String.IsNullOrEmpty(name))
            {
                CPUs = CPUs.Where(p => p.Name.Contains(name));
            }
            EditCPUsViewModel model = new EditCPUsViewModel
            {
                CPUs = CPUs,
                Name = name
            };
            return View(model);
        }

        public ViewResult EditCPU(int id)
        {
            CPU cpu = CPURepository.CPUs
                .FirstOrDefault(c => c.Id == id);
            return View(cpu);
        }

        [HttpPost]
        public ActionResult EditCPU(CPU cpu, HttpPostedFileBase image)
        {
            // изменил: HttpPostedFileBase image = null
            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    cpu.ImageMimeType = image.ContentType;
                    cpu.ImageData = new byte[image.ContentLength]; // создание массива byte
                    image.InputStream.Read(cpu.ImageData, 0, image.ContentLength); // чтение cpu.ImageData с 0 до image.ContentLength
                }
                CPURepository.SaveChanges(cpu);
                TempData["message"] = string.Format("Изменения в процессоре \"{0}\" были сохранены", cpu.Name);
                return RedirectToAction("CPU");

            }
            else
            {
                return View(cpu);
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int Id)
        {
            CPU deletedProduct = CPURepository.DeleteProduct(Id);
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

        public ActionResult GPU()
        {
            return View(GPURepository.GPUs);
        }
        // нужно добавить функционал для GPU
        public ViewResult EditGPU(int id)
        {
            GPU gpu = GPURepository.GPUs
                .FirstOrDefault(c => c.Id == id);
            return View(gpu);
        }

        [HttpPost]
        public ActionResult EditGPU(GPU gpu, HttpPostedFileBase image = null)
        {

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    gpu.ImageMimeType = image.ContentType;
                    gpu.ImageData = new byte[image.ContentLength]; // создание массива byte
                    image.InputStream.Read(gpu.ImageData, 0, image.ContentLength); // чтение cpu.ImageData с 0 до image.ContentLength
                }
                GPURepository.SaveChanges(gpu);
                TempData["message"] = string.Format("Изменения в видеокарте \"{0}\" были сохранены", gpu.Name);
                return RedirectToAction("GPU");
            }
            else
            {
                return View(gpu);
            }
        }

        [HttpPost]
        public ActionResult DeleteGPU(int Id)
        {
            CPU deletedProduct = CPURepository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Видеокарта \"{0}\" была удалена",
                    deletedProduct.Name);
            }
            return RedirectToAction("GPU");
        }
        public ViewResult CreateGPU()
        {
            return View("EditGPU", new GPU());
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
