using System.Diagnostics;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RailwayApp.Models;

namespace RailwayApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ICountryService _countryService;
    private ITrainService _trainService;
    private INewsTableService _newsTableService;

    public HomeController(ILogger<HomeController> logger, INewsTableService newsTableService, ITrainService trainService, ICountryService countryService)
    {
        _logger = logger;
        _newsTableService = newsTableService;
        _trainService = trainService;
        _countryService = countryService;
    }

    public IActionResult Index()
    {
        var news = _newsTableService.GetAll();
        return View(news);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ShowAllTrains()
    {
        var trains = _trainService.GetAllWithTypes();
        return View(trains);
    }

    public IActionResult ShowAllServices()
    {
        return View();
    }

    public IActionResult ShowOurDataAndFriends()
    {
        var countries = _countryService.GetAll();
        return View(countries);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}