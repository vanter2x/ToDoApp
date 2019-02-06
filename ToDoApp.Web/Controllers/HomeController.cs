using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Repositories;
using ToDoApp.Web.Models;

namespace ToDoApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEntityRepository<Category> _catRepository;
        private IEntityRepository<Memento> _memRepository;
        private readonly ILogger _logger;

        public HomeController(IEntityRepository<Category> catRepository,
            IEntityRepository<Memento> memRepository, ILogger logger)
        {
            _catRepository = catRepository;
            _memRepository = memRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var memModel = new MemoVM();
            foreach (var cat in _catRepository.GetAll())
            {
                memModel.ToDoList.Add(cat,new List<Memento>());
                if (_memRepository.GetAll().Any(x => x.CategoryId == cat.Id))
                {
                    foreach (var mem in _memRepository.GetAll().Where(x => x.CategoryId == cat.Id))
                    {
                        memModel.ToDoList[cat].Add(mem);
                    }
                }
            }
            
            return View(memModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
