using DependencyInjection.Models;
using DependencyInjection.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            var data = new[] { new Product { Name = "Test", Price = 100M } };

            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(p => p.Products).Returns(data);

            HomeController controller = new HomeController(mock.Object);

            ViewResult result = controller.Index();

            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
