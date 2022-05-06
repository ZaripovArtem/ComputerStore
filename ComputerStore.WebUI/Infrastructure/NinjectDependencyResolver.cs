using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using ComputerStore.Domain.Abstract;
using ComputerStore.Domain.Entities;
using ComputerStore.Domain.Concrete;
using ComputerStore.WebUI.Infrastructure.Concrete;

namespace ComputerStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    // Реализует интерфейс IDependencyResolver принадлежит пространству имен System.Web.Mvc
    // и применяется MVC Framework для получения необходимых объектов.
    // Инфраструктура MVC Framework будет вызывать метод GetService() или GetServices()
    // когда ей понадобится экземпляр класса для обслуживания входящего запроса.
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Закомментированные строки создают во временном хранилище List
            // с объектами системы. Без базы данных можно использовать их. 

            //Mock<ICPURepository> mock = new Mock<ICPURepository>();
            //mock.Setup(m => m.CPUs).Returns(new List<CPU>
            //{
            //    new CPU { Name = "Intel Celeron G5905 OEM", Price = 3499 },
            //    new CPU { Name = "AMD FX-4300 OEM", Price=3550 },
            //    new CPU { Name = "Intel Celeron G5925 OEM", Price=3699 }
            //});
            //kernel.Bind<ICPURepository>().ToConstant(mock.Object);

             kernel.Bind<ICPURepository>().To<EFCPURepository>(); // Для базы данных

            /////////////////Материнские платы/////////////////////

            //Mock<IMBRepository> mock = new Mock<IMBRepository>();
            //mock.Setup(m => m.MBs).Returns(new List<MB>
            //    {
            //        new MB { Name = "test1", Price = 5000},
            //        new MB { Name = "test2", Price = 2000 }

            //    });
            //kernel.Bind<IMBRepository>().ToConstant(mock.Object);

            kernel.Bind<IMBRepository>().To<EFMBRepository>(); //  Для базы данных

            /////////////////Видеокарты/////////////////////
            
            //var mock = new Mock<IGPURepository>();
            //mock.Setup(m => m.GPUs).Returns(new List<GPU>
            //    {
            //        new GPU { Name = "test1", Price = 5000 },
            //        new GPU { Name = "test2", Price = 2000 }

            //    });
            //kernel.Bind<IGPURepository>().ToConstant(mock.Object);

            kernel.Bind<IGPURepository>().To<EFGPURepository>(); //  Для базы данных

            ////////////////////////////////////////////////


            //var mock = new Mock<ICaseRepository>();
            //mock.Setup(m => m.Cases).Returns(new List<Case>
            //    {
            //        new Case { Name = "test1", Price = 5000 },
            //        new Case { Name = "test2", Price = 2000 }

            //    });
            //kernel.Bind<ICaseRepository>().ToConstant(mock.Object);

            kernel.Bind<ICaseRepository>().To<EFCaseRepository>();
            kernel.Bind<IFANRepository>().To<EFFANRepository>();
            kernel.Bind<IPowerRepository>().To<EFPowerRepository>();
            kernel.Bind<IRAMRepository>().To<EFRAMRepository>();
            kernel.Bind<IStorageDeviceRepository>().To<EFStorageDeviceRepository>();

            kernel.Bind<IAuthProvider>().To<FormAuthProvider>(); // Для авторизации
           


        }
    }
}