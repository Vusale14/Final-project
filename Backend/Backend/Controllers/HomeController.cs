using Backend.DAL;
using Backend.Entities;
using Backend.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class HomeController:Controller
    {
        private readonly UdemyDbContext _context;
        public HomeController(UdemyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM model = new HomeVM
            {
                Supporters = _context.Supporters.ToList(),
                Courses = _context.Courses.ToList(),
                Categories = _context.Categories.ToList()
            };
            return View(model);
        }
    }
}
