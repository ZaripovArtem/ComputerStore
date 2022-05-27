using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;
using ComputerStore.WebUI.Controllers;
using ComputerStore.WebUI.Models;
using ComputerStore.WebUI.HtmlHelpers;

namespace ComputerStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<ICPURepository> mock = new Mock<ICPURepository>();
            mock.Setup(m => m.CPUs).Returns(new List<CPU>
            {
                new CPU { Id = 1, Name = "CPU1"},
                new CPU { Id = 2, Name = "CPU2"},
                new CPU { Id = 3, Name = "CPU3"},
                new CPU { Id = 4, Name = "CPU4"},
                new CPU { Id = 5, Name = "CPU5"}
            });
            CPUController controller = new CPUController(mock.Object);
            controller.pageSize = 3;

            // Act
            CPUsListViewModel result
                = (CPUsListViewModel)controller.List(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 4);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }


        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<ICPURepository> mock = new Mock<ICPURepository>();
            mock.Setup(m => m.CPUs).Returns(new List<CPU>
            {
                new CPU { Id = 1, Name = "CPU1"},
                new CPU { Id = 2, Name = "CPU2"},
                new CPU { Id = 3, Name = "CPU3"},
                new CPU { Id = 4, Name = "CPU4"},
                new CPU { Id = 5, Name = "CPU5"}
            });
            CPUController controller = new CPUController(mock.Object);
            controller.pageSize = 4;

            // Действие (act)
            CPUsListViewModel result = (CPUsListViewModel)controller.List(2).Model;

            // Утверждение
            List<CPU> cpus = result.CPUs.ToList();
            Assert.IsTrue(cpus.Count == 1);
            Assert.AreEqual(cpus[0].Name, "CPU5");
        }

        [TestMethod]
        public void Can_Search()
        {
            // Организация (arrange)
            Mock<ICPURepository> mock = new Mock<ICPURepository>();
            mock.Setup(m => m.CPUs).Returns(new List<CPU>
            {
                new CPU { Id = 1, Name = "1", Brand="B1"},
                new CPU { Id = 2, Name = "2", Brand="B2"},
                new CPU { Id = 3, Name = "3", Brand="B1"},
                new CPU { Id = 4, Name = "4", Brand="B3"},
                new CPU { Id = 5, Name = "5", Brand="B4"}
            });
            CPUController controller = new CPUController(mock.Object);
            controller.pageSize = 3;

            // Action
            List<CPU> result = ((CPUsListViewModel)controller.List().Model)
                .CPUs.ToList();

            // Assert
            Assert.AreEqual(result.Count(), 4);
            Assert.IsTrue(result[0].Name == "1" && result[0].Brand == "B1");
            Assert.IsTrue(result[1].Name == "2" && result[1].Brand == "B2");
        }

        [TestMethod]
        public void Can_Add_In_Order()
        {
            // Организация - создание нескольких тестовых игр
            CPU cpu1 = new CPU { Id = 1, Name = "Процессор 1", Price = 123 };
            GPU gpu1 = new GPU { Id = 1, Name = "Видеокарта 1", Price = 333 };

            Cart cart = new Cart();

            cart.AddItem(cpu1, 1, cpu1.Name, cpu1.Price);
            cart.AddItemGPU(gpu1, 2, gpu1.Name, gpu1.Price);
            List<CartLine> results = cart.Lines.ToList();

            Assert.AreEqual(results.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Products()
        {
            CPU cpu1 = new CPU { Id = 1, Name = "Процессор 1", Price = 123 };
            GPU gpu1 = new GPU { Id = 1, Name = "Видеокарта 1", Price = 333 };

            Cart cart = new Cart();

            cart.AddItem(cpu1, 1, cpu1.Name, cpu1.Price);
            cart.AddItemGPU(gpu1, 2, gpu1.Name, gpu1.Price);

            decimal result = cart.ComputeTotalValue();
            Assert.AreEqual(result, 789);
        }
    }
}