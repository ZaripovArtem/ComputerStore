using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;
using ComputerStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ComputerStore.Domain.Concrete;
using System.Diagnostics;

namespace ComputerStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly Service service;

        private ICPURepository repository;
        private IMBRepository MBRepository;
        private IGPURepository GPURepository;
        private IRAMRepository RAMRepository;
        private ICaseRepository CaseRepository;
        private IFANRepository FANRepository;
        private IPowerRepository PowerRepository;
        private IStorageDeviceRepository StorageDeviceRepository;

        public CartController(IMBRepository repo, ICPURepository rep, IGPURepository repGPU, IRAMRepository repRAM, ICaseRepository repCase, IFANRepository repFAN, IPowerRepository repPower, IStorageDeviceRepository repSD, Service service)
        {
            repository = rep;
            MBRepository = repo;
            GPURepository = repGPU;
            RAMRepository = repRAM;
            CaseRepository = repCase;
            FANRepository = repFAN;
            PowerRepository = repPower;
            StorageDeviceRepository = repSD;

            this.service = service;
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, string returnUrl)
        {
            cart.RemoveLine();
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl)
        {
            CPU cpu = repository.CPUs
                .FirstOrDefault(g => g.Id == Id);

            if (cpu != null)
            {
                cart.AddItem(cpu, 1, cpu.Name, cpu.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult AddToCartMB(Cart cart, int Id, string returnUrl)
        {
            MB mb = MBRepository.MBs
              .FirstOrDefault(g => g.Id == Id);

            if (mb != null)
            {
                cart.AddItemMB(mb, 1, mb.Name, mb.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult AddToCartGPU(Cart cart, int Id, string returnUrl)
        {
            GPU gpu = GPURepository.GPUs
              .FirstOrDefault(g => g.Id == Id);

            if (gpu != null)
            {
                cart.AddItemGPU(gpu, 1, gpu.Name, gpu.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult AddToCartRAM(Cart cart, int Id, string returnUrl)
        {
            RAM ram = RAMRepository.RAMs
              .FirstOrDefault(g => g.Id == Id);

            if (ram != null)
            {
                cart.AddItemRAM(ram, 1, ram.Name, ram.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult AddToCartCase(Cart cart, int Id, string returnUrl)
        {
            Case Case = CaseRepository.Cases
              .FirstOrDefault(g => g.Id == Id);

            if (Case != null)
            {
                cart.AddItemCase(Case, 1, Case.Name, Case.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult AddToCartPower(Cart cart, int Id, string returnUrl)
        {
            Power power = PowerRepository.Powers
              .FirstOrDefault(g => g.Id == Id);

            if (power != null)
            {
                cart.AddItemPower(power, 1, power.Name, power.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult AddToCartFAN(Cart cart, int Id, string returnUrl)
        {
            FAN fan = FANRepository.FANs
              .FirstOrDefault(g => g.Id == Id);

            if (fan != null)
            {
                cart.AddItemFAN(fan, 1, fan.Name, fan.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult AddToCartStorageDevice(Cart cart, int Id, string returnUrl)
        {
            StorageDevice StorageDevice = StorageDeviceRepository.StorageDevices
              .FirstOrDefault(g => g.Id == Id);

            if (StorageDevice != null)
            {
                cart.AddItemStorageDevice(StorageDevice, 1, StorageDevice.Name, StorageDevice.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
                return View("Checkout");
            }

            if (ModelState.IsValid)
            {
                service.SendEmailCustom(cart, shippingDetails);
                cart.Clear();
                cart.RemoveLine();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult SendEmailCustom(Cart cart, ShippingDetails shippingDetails)
        {
            service.SendEmailCustom(cart, shippingDetails);
            return View("Index");
        }
      
    }
}