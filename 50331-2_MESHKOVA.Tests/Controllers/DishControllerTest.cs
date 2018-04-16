using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _50331_2_MESHKOVA.DAL.Entities;
using _50331_2_MESHKOVA.DAL.Interfaces;
using _50331_2_MESHKOVA.Models;
using _50331_2_MESHKOVA.Controllers;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Collections.Generic;

namespace _50331_2_MESHKOVA.Tests.Controllers
{
    [TestClass]
    public class DishControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {
            //Arrange
            //Макет репозитория
            var mock = new Mock<IRepository<Dish>>();
            mock.Setup(r => r.GetAll()).Returns(new List<Dish> {
                new Dish {DishID=1 },
                new Dish {DishID=2 },
                new Dish {DishID=3 },
                new Dish {DishID=4 },
                new Dish {DishID=5 },
            });
            //Создание объекта контроллера
            var controller = new DishController(mock.Object);

            //Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            //Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            //Act
            //Вызов метода List
            var view = controller.List(null, 2) as ViewResult;

            //Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Dish> model = view.Model as PageListViewModel<Dish>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].DishID);
            Assert.AreEqual(5, model[1].DishID);
        }


        [TestMethod]
        public void CategoryTest()
        {
            //Arrange
            //Макет репозитория
            var mock = new Mock<IRepository<Dish>>();
            mock.Setup(r => r.GetAll()).Returns(new List<Dish> {
                new Dish {DishID=1,GroupName="1" },
                new Dish {DishID=2,GroupName="2" },
                new Dish {DishID=3,GroupName="1" },
                new Dish {DishID=4,GroupName="2" },
                new Dish {DishID=5,GroupName="2" },
            });
            //Создание объекта контроллера
            var controller = new DishController(mock.Object);

            //Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            //Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            //Act
            //Вызов метода List
            var view = controller.List("1", 1) as ViewResult;

            //Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Dish> model = view.Model as PageListViewModel<Dish>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].DishID);
            Assert.AreEqual(3, model[1].DishID);
        }

    }
}
