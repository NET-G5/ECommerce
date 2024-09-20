using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class WishListController : Controller
{
    private readonly IProductService _productService;
    private readonly IWishListService _wishListService;

    public WishListController(IProductService productService, IWishListService wishListService)
    {
        _productService = productService;
        _wishListService = wishListService;
    }
    // GET: WishListController
    public ActionResult Index(int customerId)
    {
        var wishList = _wishListService.GetAll(customerId);

        ViewBag.Products = wishList.Select(x => x.Products);

        return View(wishList);
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
}
