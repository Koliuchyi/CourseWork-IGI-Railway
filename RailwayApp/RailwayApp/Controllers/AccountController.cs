using Microsoft.AspNetCore.Mvc;
using RailwayApp.Models;

namespace RailwayApp.Controllers;

public class AccountController : Controller
{
    public IActionResult Authorization()
    {
        return View(new AuthorizationViewModel());
    }
    
    [HttpPost]
    public IActionResult Authorization(AuthorizationViewModel model)
    {

        return RedirectToAction("Index", "Home");

    }

    public IActionResult Registration()
    {
        return View(new RegistrationViewModel());
    }
    
    [HttpPost]
    public IActionResult Registration(RegistrationViewModel model)
    {
        if (ModelState.IsValid)
        {
            
            return RedirectToAction("Registration");
        }
        else
        {
            return View(model);
        }
    }
}