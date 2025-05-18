using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartBootstrap.DAL;
using StartBootstrap.Models;
using StartBootstrap.Utilites.Enam;
using StartBootstrap.Utilites.Extenions;
using StartBootstrap.ViewModels.ProductVM;

namespace StartBootstrap.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index()

        {
            List<GetProductVM> productVM = await _context.Products.Select(p => new GetProductVM
            {
                Name = p.Name,
                Category = p.Category,
                Image = p.Image,

            }).ToListAsync();




            return View(productVM);
        }
        public async Task<IActionResult> Create()
        {
            CreateProductVM productVM = new CreateProductVM
            {
                Categories = await _context.Categories.ToListAsync()
            };
            return View(productVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM productVM)
        {
            productVM.Categories = await _context.Categories.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(productVM);
            }
            bool result = productVM.Categories.Any(c => c.Id == productVM.CategoryId);
            if (!result)
            {
                ModelState.AddModelError(nameof(CreateProductVM.CategoryId), "categorya movcude deyil");
                return View(productVM);
            }
            if (!productVM.MainPhoto.ValidateType("/image"))
            {
                ModelState.AddModelError(nameof(CreateProductVM.MainPhoto), "file tipi uygun deyil");
            }
            if (!productVM.MainPhoto.ValidateSize(FileSize.GB,500))
            {
                ModelState.AddModelError(nameof(CreateProductVM.MainPhoto), "file olcusu uygun deyl");
                return View(productVM);
            }
            bool nameResult= await _context.Products.AnyAsync(p=>p.Name==productVM.Name);
            if (!nameResult) 
            {
                ModelState.AddModelError(nameof(CreateProductVM.Name), "Mehsul artiq movcudur");
                return View(productVM);
            }
            string imageName = await productVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img", "portfolio");
            Product product = new Product
            {
                Name = productVM.Name,
                Image = imageName,
                CategoryId = productVM.CategoryId.Value,
                


            };
            await _context.Products.AddAsync(product);  
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
