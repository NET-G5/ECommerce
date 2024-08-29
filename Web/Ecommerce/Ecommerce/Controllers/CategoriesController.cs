using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Category;
using Ecommerce.Mappings;

namespace Ecommerce.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();

            return View(categories);
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
            
            var viewModel=category.ToUpdateViewModel();

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
