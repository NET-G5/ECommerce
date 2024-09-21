using Ecommerce.Mappings;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index(string searchText)
        {
            var products = _productService.GetAll(searchText);

            ViewBag.Products = products;
            ViewBag.SearchText = searchText;

            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById(id.Value);

            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryViewModel createCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(createCategoryViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(createCategoryViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById(id.Value);

            if (category is null)
            {
                return NotFound();
            }

            var viewModel = category.ToUpdateViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateCategoryViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Update(viewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(viewModel.Id))
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
            return View(viewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetById(id.Value);

            if (category is null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _categoryService.GetById(id);

            if (category is null)
            {
                return NotFound();
            }

            _categoryService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _categoryService.GetById(id) is not null;
        }
    }
}
