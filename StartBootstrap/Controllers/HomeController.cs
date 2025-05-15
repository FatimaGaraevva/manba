
using Microsoft.AspNetCore.Mvc;
using StartBootstrap.DAL;
using StartBootstrap.ViewModels;

namespace StartBootstrap.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context=context;
        }

        public async Task< IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Products = _context.Products.Take(8).ToList()
            };

            return View(homeVM);
        }

    

    }
}
