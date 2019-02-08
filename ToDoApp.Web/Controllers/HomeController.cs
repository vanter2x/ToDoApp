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
            var memModel = new MemosVM();
            memModel.Categories.AddRange(_catRepository.GetAll());
            memModel.Mementoes.AddRange(_memRepository.GetAll());

            return View(memModel);
        }

        public IActionResult About()
        {
            
            return View();
        }

        
        public IActionResult DeleteMemento(int id)
        {
            var memo = _memRepository.GetSingle(id);
            _memRepository.Delete(memo);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = _catRepository.GetSingle(id);
            var catMementos = _memRepository.GetAll().Where(x => x.CategoryId == category.Id);
            if (catMementos != null)
            {
                foreach (var memento in catMementos)
                {
                    _memRepository.Delete(memento);
                }
            }
            _catRepository.Delete(category);

            return RedirectToAction("Index");
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
