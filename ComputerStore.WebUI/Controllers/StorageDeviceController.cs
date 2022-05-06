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
    public class StorageDeviceController : Controller
    {
        private IStorageDeviceRepository repository;

        public StorageDeviceController(IStorageDeviceRepository rep)
        {
            repository = rep;
        }

        public ViewResult List(int page = 1, SortState sortState = SortState.NameAsc)
        {
            IEnumerable<StorageDevice> StorageDevices = repository.StorageDevices;
            int pageSize = 4; // количество товара на 1 странице
            // сортировка
            switch (sortState)
            {
                case SortState.NameDesc:
                    StorageDevices = StorageDevices.OrderByDescending(p => p.Name);
                    break;
                case SortState.PriceAsc:
                    StorageDevices = StorageDevices.OrderBy(p => p.Price);
                    break;
                case SortState.PriceDesc:
                    StorageDevices = StorageDevices.OrderByDescending(p => p.Price);
                    break;
                default:
                    StorageDevices = StorageDevices.OrderBy(p => p.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
                    break;
            }

            StorageDevicesListViewModel model = new StorageDevicesListViewModel
            {
                StorageDevices = StorageDevices,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.StorageDevices.Count()
                }
            };

            return View(model);
        }
        public FileContentResult GetImage(int id)
        {
            StorageDevice StorageDevice = repository.StorageDevices
                .FirstOrDefault(c => c.Id == id);
            if (StorageDevice != null)
            {
                return File(StorageDevice.ImageData, StorageDevice.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}