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
        public void Can_Generate_Page_Links()
        {

            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Организация - настройка делегата с помощью лямбда-выражения
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Организация (arrange)
            Mock<ICPURepository> mock = new Mock<ICPURepository>();
            mock.Setup(m => m.CPUs).Returns(new List<CPU>
    {
        new CPU { CPUId = 1, Name = "CPU1"},
        new CPU { CPUId = 2, Name = "CPU2"},
        new CPU { CPUId = 3, Name = "CPU3"},
        new CPU { CPUId = 4, Name = "CPU4"},
        new CPU { CPUId = 5, Name = "CPU5"}
    });
            CPUController controller = new CPUController(mock.Object);
            controller.pageSize = 3;

            // Act
            CPUsListViewModel result
                = (CPUsListViewModel)controller.List(2).Model;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
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
            new CPU { CPUId = 1, Name = "CPU1"},
            new CPU { CPUId = 2, Name = "CPU2"},
            new CPU { CPUId = 3, Name = "CPU3"},
            new CPU { CPUId = 4, Name = "CPU4"},
            new CPU { CPUId = 5, Name = "CPU5"}
        });
            CPUController controller = new CPUController(mock.Object);
            controller.pageSize = 3;

            // Действие (act)
            CPUsListViewModel result = (CPUsListViewModel)controller.List(2).Model;

            // Утверждение
            List<CPU> cpus = result.CPUs.ToList();
            Assert.IsTrue(cpus.Count == 2);
            Assert.AreEqual(cpus[0].Name, "Игра4");
            Assert.AreEqual(cpus[1].Name, "Игра5");
        }


    }
}