using System;
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
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productVM = await _productService.GetById(id);
            if (productVM == null) return NotFound();
             
            
            return View(productVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            try
            {
                _productService.Update(productViewModel);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var productVm = await _productService.GetById(id);
            if (productVm == null) return NotFound();
            
            return View(productVm);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var productVm = await _productService.GetById(id);
            if (productVm == null) return NotFound();
            
            return View(productVm);
            
        }

        [HttpPost(), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var productVm = _productService.GetById(id);
            if (productVm == null) return NotFound();

            _productService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}