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

        public CartController(IMBRepository repo, ICPURepository rep, Service service)
        {
            MBRepository = repo;
            repository = rep;


            this.service = service;
            //orderProcessor = processor;///
        }
        public RedirectToRouteResult AddToCart(Cart cart, int cpuId, string returnUrl) // Cart cart, 
        {
            CPU cpu = repository.CPUs
                .FirstOrDefault(g => g.CPUId == cpuId);

            if (cpu != null)
            {
                //GetCart().AddItem(cpu, 1, cpu.Name, cpu.Price); //////////////cpu.Name
                cart.AddItem(cpu, 1, cpu.Name, cpu.Price); // изменено

            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, string returnUrl) // Cart cart   int cpuId,
        {

            //CPU cpu = repository.CPUs
            //    .FirstOrDefault(g => g.CPUId == cpuId);

            //if (cpu != null)
            //{

            //    cart.RemoveLine(cpu);
            //}
            //cart.RemoveLine(cart);

            cart.RemoveLine();
           

            return RedirectToAction("Index", new { returnUrl });


        }




        //public ViewResult Index(string returnUrl)
        //{
        //    return View(new CartIndexViewModel
        //    {
        //        Cart = GetCart(),
        //        ReturnUrl = returnUrl
        //    });
        //}


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
            //MB mb = MBRepository.MBs
            //    .FirstOrDefault(g => g.MBId == mbId);

            //if (mb != null)
            //{
            //    //GetCart().AddItemMB(mb, 1, mb.Name, mb.Price); //////////////////////////
            //    cart.AddItemMB(mb, 1, mb.Name, mb.Price);
            //}
            //return RedirectToAction("Index", new { returnUrl });
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
            }

            if (ModelState.IsValid)
            {
                service.SendEmailCustom(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }


        public ViewResult SendEmailCustom(Cart cart, ShippingDetails shippingDetails) /////тут
        {
            service.SendEmailCustom(cart, shippingDetails); //////////тут
            return View("Index");
        }
      
    }
}