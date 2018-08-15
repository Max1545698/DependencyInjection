using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        //private IRepository repository;

        //public HomeController(IRepository repo)
        //{
        //    repository = repo;
        //}
        public ViewResult Index([FromServices] ProductTotilizer totilizer)
        {
            IRepository repository = HttpContext.RequestServices.GetService<IRepository>();
            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = totilizer.Repository.ToString();
            return View(repository.Products);
        }
    }
}