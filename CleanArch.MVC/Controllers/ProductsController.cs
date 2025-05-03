using System.Threading.Tasks;
using CleanArch.Application.Interface;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var products =  await _productService.GetAll();
            return View(products);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(ProductViewModel productViewModel)
        { 
            if (!ModelState.IsValid) return View(productViewModel);
            
            _productService.Add(productViewModel);
            return RedirectToAction(nameof(Index));
        }
        
        
    }
}