using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RailwayApp.Models;

namespace RailwayApp.Controllers;

public class AccountController : Controller
{
    private IClientService _clientService;
    private IRailwayStaffService _railwayStaffService;

    public AccountController(IClientService clientService, IRailwayStaffService railwayStaffService)
    {
        _clientService = clientService;
        _railwayStaffService = railwayStaffService;
    }
    public IActionResult Authorization()
    {
        return View(new AuthorizationViewModel());
    }
    
    [HttpPost]
    public IActionResult Authorization(AuthorizationViewModel model)
    {
        ClientDTO client = _clientService.GetAll().FirstOrDefault(cl => cl.Password == model.Password && cl.Email == model.Login);
        if (client == null)
        {
            RailwayStaffDTO staff = _railwayStaffService.GetAll().FirstOrDefault(cl => cl.Password == model.Password && cl.Email == model.Login);
            if (staff == null)
            {
                ViewBag.ErrorMessage = "Ошибка авторизации! Пожалуйста, проверьте введенные данные.";
                return View();
            }
            if(staff.Role == "Admin")
                return RedirectToAction("Index", "Admin");
            return RedirectToAction("Index", "Manager");
        }
        return RedirectToAction("Index", "Client", new {Id = client.Id});
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
            ClientDTO client = new ClientDTO();
            client.Email = model.Email;
            client.Password = model.Password;
            client.Name = model.Name;
            client.LastName = model.LastName;
            client.ContactNumber = model.ContactNumber;
            client.PassportData = model.PassportData;
            _clientService.Add(client);
            return RedirectToAction("Index", "Client", new {Client = client});
        }
        return View(model);

    }
}