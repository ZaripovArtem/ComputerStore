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

        private IOrderProcessor orderProcessor;///

        private ICPURepository repository;
        private IMBRepository MBRepository;
        private IGPURepository GPURepository;

        public CartController(IMBRepository repo, ICPURepository rep, IGPURepository repGPU, Service service)
        {
            MBRepository = repo;
            repository = rep;
            GPURepository = repGPU;

            this.service = service;
        }
        public RedirectToRouteResult AddToCart(Cart cart, int cpuId, string returnUrl) // Cart cart, 
        {
            CPU cpu = repository.CPUs
                .FirstOrDefault(g => g.CPUId == cpuId);

            if (cpu != null)
            {
                cart.AddItem(cpu, 1, cpu.Name, cpu.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, string returnUrl) // Cart cart   int cpuId,
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

        ///////////////////////////////МАТЕРИНСКИЕ ПЛАТЫ///////////////////////////////////////

        public RedirectToRouteResult AddToCartMB(Cart cart, int mbId, string returnUrl)
        {
            MB mb = MBRepository.MBs
              .FirstOrDefault(g => g.MBId == mbId);

            if (mb != null)
            {
                cart.AddItemMB(mb, 1, mb.Name, mb.Price);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCartMB(Cart cart, int mbId, string returnUrl)
        {
            MB mb = MBRepository.MBs // поставил MBRepository
                .FirstOrDefault(g => g.MBId == mbId);

            if (mb != null)
            {
                //GetCart().RemoveLineMB(mb);
                cart.RemoveLineMB(mb);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        ///////////////////////////////ВИДЕОКАРТЫ/////////////////////////////////////

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


        /// /////////////////////////////////////////////////////////////////////////////////


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