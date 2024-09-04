using Ecommerce.Domain.Entities;
using Ecommerce.Mappings;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels.Customer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Controllers
{
    public class CustomerController:Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
             _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(CreateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.DateRegistered= DateTime.UtcNow;

                try
                {
                    _customerService.Create(model);

                    ModelState.Clear();

                    ViewBag.Message = $"{model.FirstName} {model.LastName} registered successfully. Please Login.";
                }
                catch (DbUpdateException exception)
                {
                    ModelState.AddModelError("", "Pleas, Enter unique Email or Password");

                    return View(model);
                }

                return RedirectToAction("Login");
            }


            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _customerService.GetAll().Where(x => (x.Email == model.Email ) && x.Password == model.Password).FirstOrDefault();

                ViewBag.Name = user.FirstName;

                if (user is not null)
                {
                    var claim = new List<Claim>
                    {
                        new (ClaimTypes.Name, user.Email),
                        new ("Name", user.FirstName),
                        new (ClaimTypes.Role, "User"),  
                    };

                    var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index","Products");
                }
                else
                {
                    ModelState.AddModelError("", "Username/Email or Password is not correct");
                }
            }

            return View(model);
        }
     
    }
}
