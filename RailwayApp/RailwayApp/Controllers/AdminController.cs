using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RailwayApp.Controllers;

public class AdminController : Controller
{
    private INewsTableService _newsService;
    private IRailwayStaffService _staffService;

    public AdminController(INewsTableService newsService, IRailwayStaffService staffService)
    {
        _newsService = newsService;
        _staffService = staffService;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ShowAllStaff()
    {
        var items = _staffService.GetAll();
        return View(items);
    }

    [HttpGet]
    public IActionResult CreateStaff()
    {
        ViewBag.Staff = _staffService.GetAll();
        return View();
    }
    [HttpPost]
    public IActionResult CreateStaff(RailwayStaffDTO item)
    {
        ViewBag.Staff = _staffService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _staffService.Add(item);
            return RedirectToAction(nameof(ShowAllStaff));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateStaff(int id)
    {
        var item = _staffService.GetById(id);
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateStaff(RailwayStaffDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _staffService.Update(item);
            return RedirectToAction(nameof(ShowAllStaff));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteStaff(int id)
    {
        var item = _staffService.GetById(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllStaff));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteStaff(RailwayStaffDTO item)
    {
        _staffService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllStaff));
    }
    
    public IActionResult ShowAllNews()
    {
        var items = _newsService.GetAll();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult CreateNews()
    {
        ViewBag.News = _newsService.GetAll();
        return View();
    }
    [HttpPost]
    public IActionResult CreateNews(NewsTableDTO item)
    {
        ViewBag.News = _newsService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _newsService.Add(item);
            return RedirectToAction(nameof(ShowAllNews));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateNews(int id)
    {
        var item = _newsService.GetById(id);
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateNews(NewsTableDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _newsService.Update(item);
            return RedirectToAction(nameof(ShowAllNews));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteNews(int id)
    {
        var item = _newsService.GetById(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllNews));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteNews(NewsTableDTO item)
    {
        _newsService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllNews));
    }

    public IActionResult Exit()
    {
       return RedirectToAction("Index", "Home");
    }
}