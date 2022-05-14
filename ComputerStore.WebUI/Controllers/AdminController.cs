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
        ICPURepository CPURepository;
        IMBRepository MBRepository;
        IGPURepository GPURepository;
        IRAMRepository RAMRepository;
        ICaseRepository CaseRepository;
        IFANRepository FANRepository;
        IPowerRepository PowerRepository;
        IStorageDeviceRepository SDRepository;

        public AdminController (ICPURepository CPUrep, IMBRepository MBrep, IGPURepository GPUrep, IRAMRepository RAMrep, ICaseRepository Caserep, IFANRepository FANrep, IPowerRepository Powerrep, IStorageDeviceRepository SDrep)
        {
            CPURepository = CPUrep;
            MBRepository = MBrep;
            GPURepository = GPUrep;
            RAMRepository = RAMrep;
            CaseRepository = Caserep;
            FANRepository = FANrep;
            PowerRepository = Powerrep;
            SDRepository = SDrep;
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

        public ActionResult GPU(string name)
        {
            IEnumerable<GPU> GPUs = GPURepository.GPUs;
            if (!String.IsNullOrEmpty(name))
            {
                GPUs = GPUs.Where(p => p.Name.Contains(name));
            }
            EditGPUsViewModel model = new EditGPUsViewModel
            {
                GPUs = GPUs,
                Name = name
            };
            return View(model);
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

        public ActionResult MB(string name)
        {
            IEnumerable<MB> MBs = MBRepository.MBs;
            if (!String.IsNullOrEmpty(name))
            {
                MBs = MBs.Where(p => p.Name.Contains(name));
            }
            EditMBsViewModel model = new EditMBsViewModel
            {
                MBs = MBs,
                Name = name
            };
            return View(model);
        }

        public ViewResult CreateMB()
        {
            return View("EditMB", new MB());
        }

        public ViewResult EditMB(int id)
        {
            MB mb = MBRepository.MBs
                .FirstOrDefault(c => c.Id == id);
            return View(mb);
        }

        [HttpPost]
        public ActionResult EditMB(MB mb, HttpPostedFileBase image = null)
        {

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    mb.ImageMimeType = image.ContentType;
                    mb.ImageData = new byte[image.ContentLength]; // создание массива byte
                    image.InputStream.Read(mb.ImageData, 0, image.ContentLength); // чтение cpu.ImageData с 0 до image.ContentLength
                }
                MBRepository.SaveChanges(mb);
                TempData["message"] = string.Format("Изменения в видеокарте \"{0}\" были сохранены", mb.Name);
                return RedirectToAction("MB");
            }
            else
            {
                return View(mb);
            }
        }

        [HttpPost]
        public ActionResult DeleteMB(int Id)
        {
            MB deletedProduct = MBRepository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Материнская плата \"{0}\" была удалена",
                    deletedProduct.Name);
            }
            return RedirectToAction("MB");
        }

        public ActionResult RAM(string name)
        {
            IEnumerable<RAM> RAMs = RAMRepository.RAMs;
            if (!String.IsNullOrEmpty(name))
            {
                RAMs = RAMs.Where(p => p.Name.Contains(name));
            }
            EditRAMsViewModel model = new EditRAMsViewModel
            {
                RAMs = RAMs,
                Name = name
            };
            return View(model);
        }

        public ViewResult CreateRAM()
        {
            return View("EditRAM", new RAM());
        }

        public ViewResult EditRAM(int id)
        {
            RAM ram = RAMRepository.RAMs
                .FirstOrDefault(c => c.Id == id);
            return View(ram);
        }

        [HttpPost]
        public ActionResult EditRAM(RAM ram, HttpPostedFileBase image = null)
        {

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    ram.ImageMimeType = image.ContentType;
                    ram.ImageData = new byte[image.ContentLength]; // создание массива byte
                    image.InputStream.Read(ram.ImageData, 0, image.ContentLength); // чтение cpu.ImageData с 0 до image.ContentLength
                }
                RAMRepository.SaveChanges(ram);
                TempData["message"] = string.Format("Изменения в оперативной памяти \"{0}\" были сохранены", ram.Name);
                return RedirectToAction("RAM");
            }
            else
            {
                return View(ram);
            }
        }

        [HttpPost]
        public ActionResult DeleteRAM(int Id)
        {
            RAM deletedProduct = RAMRepository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Оперативная память \"{0}\" была удалена",
                    deletedProduct.Name);
            }
            return RedirectToAction("RAM");
        }

        public ActionResult Case(string name)
        {
            IEnumerable<Case> Cases = CaseRepository.Cases;
            if (!String.IsNullOrEmpty(name))
            {
                Cases = Cases.Where(p => p.Name.Contains(name));
            }
            EditCasesViewModel model = new EditCasesViewModel
            {
                Cases = Cases,
                Name = name
            };
            return View(model);
        }

        public ViewResult CreateCase()
        {
            return View("EditCase", new Case());
        }

        public ViewResult EditCase(int id)
        {
            Case Case = CaseRepository.Cases
                .FirstOrDefault(c => c.Id == id);
            return View(Case);
        }

        [HttpPost]
        public ActionResult EditCase(Case Case, HttpPostedFileBase image = null)
        {

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    Case.ImageMimeType = image.ContentType;
                    Case.ImageData = new byte[image.ContentLength]; // создание массива byte
                    image.InputStream.Read(Case.ImageData, 0, image.ContentLength); // чтение cpu.ImageData с 0 до image.ContentLength
                }
                CaseRepository.SaveChanges(Case);
                TempData["message"] = string.Format("Изменения в корпусе \"{0}\" были сохранены", Case.Name);
                return RedirectToAction("Case");
            }
            else
            {
                return View(Case);
            }
        }

        [HttpPost]
        public ActionResult DeleteCase(int Id)
        {
            Case deletedProduct = CaseRepository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Корпус \"{0}\" был удален",
                    deletedProduct.Name);
            }
            return RedirectToAction("Case");
        }

        public ActionResult Power(string name)
        {
            IEnumerable<Power> Powers = PowerRepository.Powers;
            if (!String.IsNullOrEmpty(name))
            {
                Powers = Powers.Where(p => p.Name.Contains(name));
            }
            EditPowersViewModel model = new EditPowersViewModel
            {
                Powers = Powers,
                Name = name
            };
            return View(model);
        }

        public ViewResult CreatePower()
        {
            return View("EditPower", new Power());
        }

        public ViewResult EditPower(int id)
        {
            Power power = PowerRepository.Powers
                .FirstOrDefault(c => c.Id == id);
            return View(power);
        }

        [HttpPost]
        public ActionResult EditPower(Power power, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    power.ImageMimeType = image.ContentType;
                    power.ImageData = new byte[image.ContentLength]; // создание массива byte
                    image.InputStream.Read(power.ImageData, 0, image.ContentLength); // чтение cpu.ImageData с 0 до image.ContentLength
                }
                PowerRepository.SaveChanges(power);
                TempData["message"] = string.Format("Изменения в блоке питания \"{0}\" были сохранены", power.Name);
                return RedirectToAction("Power");
            }
            else
            {
                return View(power);
            }
        }

        [HttpPost]
        public ActionResult DeletePower(int Id)
        {
            Power deletedProduct = PowerRepository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Блок питания \"{0}\" был удален",
                    deletedProduct.Name);
            }
            return RedirectToAction("Power");
        }

        public ActionResult FAN(string name)
        {
            IEnumerable<FAN> FANs = FANRepository.FANs;
            if (!String.IsNullOrEmpty(name))
            {
                FANs = FANs.Where(p => p.Name.Contains(name));
            }
            EditFANsViewModel model = new EditFANsViewModel
            {
                FANs = FANs,
                Name = name
            };
            return View(model);
        }

        public ViewResult CreateFAN()
        {
            return View("EditFAN", new FAN());
        }

        public ViewResult EditFAN(int id)
        {
            FAN fan = FANRepository.FANs
                .FirstOrDefault(c => c.Id == id);
            return View(fan);
        }

        [HttpPost]
        public ActionResult EditFAN(FAN fan, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    fan.ImageMimeType = image.ContentType;
                    fan.ImageData = new byte[image.ContentLength]; // создание массива byte
                    image.InputStream.Read(fan.ImageData, 0, image.ContentLength); // чтение cpu.ImageData с 0 до image.ContentLength
                }
                FANRepository.SaveChanges(fan);
                TempData["message"] = string.Format("Изменения в куллере \"{0}\" были сохранены", fan.Name);
                return RedirectToAction("FAN");
            }
            else
            {
                return View(fan);
            }
        }

        [HttpPost]
        public ActionResult DeleteFAN(int Id)
        {
            FAN deletedProduct = FANRepository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Блок питания \"{0}\" был удален",
                    deletedProduct.Name);
            }
            return RedirectToAction("FAN");
        }

        public ActionResult StorageDevice(string name)
        {
            IEnumerable<StorageDevice> StorageDevices = SDRepository.StorageDevices;
            if (!String.IsNullOrEmpty(name))
            {
                StorageDevices = StorageDevices.Where(p => p.Name.Contains(name));
            }
            EditStorageDevicesViewModel model = new EditStorageDevicesViewModel
            {
                StorageDevices = StorageDevices,
                Name = name
            };
            return View(model);
        }

        public ViewResult CreateStorageDevice()
        {
            return View("EditStorageDevice", new StorageDevice());
        }

        public ViewResult EditStorageDevice(int id)
        {
            StorageDevice sd = SDRepository.StorageDevices
                .FirstOrDefault(c => c.Id == id);
            return View(sd);
        }

        [HttpPost]
        public ActionResult EditStorageDevice(StorageDevice sd, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    sd.ImageMimeType = image.ContentType;
                    sd.ImageData = new byte[image.ContentLength]; // создание массива byte
                    image.InputStream.Read(sd.ImageData, 0, image.ContentLength); // чтение cpu.ImageData с 0 до image.ContentLength
                }
                SDRepository.SaveChanges(sd);
                TempData["message"] = string.Format("Изменения в носителе \"{0}\" были сохранены", sd.Name);
                return RedirectToAction("StorageDevice");
            }
            else
            {
                return View(sd);
            }
        }

        [HttpPost]
        public ActionResult DeleteStorageDevice(int Id)
        {
            StorageDevice deletedProduct = SDRepository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Носитель \"{0}\" был удален",
                    deletedProduct.Name);
            }
            return RedirectToAction("StorageDevice");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
