using Ecommerce.Mappings;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index(string searchText)
        {
            var products = _productService.GetAll(searchText);
            return View(products);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetById(id.Value);
            if (product is null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductViewModel product, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    image.CopyTo(stream);
                    product.ImageUrl = stream.ToArray();
                }
            }

            var createdProduct = _productService.Create(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetById(id.Value);

            if (product is null)
            {
                return NotFound();
            }
            var viewModel = product.ToUpdateViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateProductViewModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetById(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productService.GetById(id);
            if (product is null)
            {
                return NotFound();
            }

            _productService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _productService.GetById(id) is not null;
        }
    }
}
