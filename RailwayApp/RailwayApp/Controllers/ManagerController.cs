using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using RailwayApp.Models;

namespace RailwayApp.Controllers;

public class ManagerController : Controller
{
    private ITrainService _trainService;
    private ITypeTrainService _typeTrainService;
    private ICarriageService _carriageService;
    private ITypeCarriageService _typeCarriageService;
    private ICountryService _countryService;
    private ICityService _cityService;
    private IStationService _stationService;
    private IRouteService _routeService;
    private IRouteStopService _routeStopService;
    private string pathForRoutes = "E:\\Учёба Университет\\ИГИ\\Курсовая работа\\RailwayApp\\RailwayApp\\RoutesData.json";
    CombineRouteViewModel _combineRouteViewModel = new CombineRouteViewModel();
    
    public ManagerController(ITrainService trainService, ITypeTrainService typeTrainService,
        ICarriageService carriageService, ITypeCarriageService typeCarriageService, ICountryService countryService,
        ICityService cityService, IStationService stationService, IRouteService routeService, IRouteStopService routeStopService)
    {
        _trainService = trainService;
        _typeTrainService = typeTrainService;
        _carriageService = carriageService;
        _typeCarriageService = typeCarriageService;
        _countryService = countryService;
        _cityService = cityService;
        _stationService = stationService;
        _routeService = routeService;
        _routeStopService = routeStopService;
        _combineRouteViewModel.StopModels = new List<RouteStopViewModel>();
        _combineRouteViewModel.MainRoute = new RouteViewModel();
    }
    public IActionResult Index()
    {
        return View();
    }
    /////////////////////////////////////////////////// Типы поездов
    public IActionResult ShowAllTypeTrain()
    {
        var items = _typeTrainService.GetAll();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult CreateTypeTrain()
    {
        ViewBag.TypeTrain = _typeTrainService.GetAll();
        return View();
    }
    [HttpPost]
    public IActionResult CreateTypeTrain(TypeTrainDTO item)
    {
        ViewBag.TypeTrain = _typeTrainService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _typeTrainService.Add(item);
            return RedirectToAction(nameof(ShowAllTypeTrain));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateTypeTrain(int id)
    {
        var item = _typeTrainService.GetById(id);
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateTypeTrain(TypeTrainDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _typeTrainService.Update(item);
            return RedirectToAction(nameof(ShowAllTypeTrain));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteTypeTrain(int id)
    {
        var item = _typeTrainService.GetById(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllTypeTrain));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteTypeTrain(TypeTrainDTO item)
    {
        _typeTrainService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllTypeTrain));
    }
    
    /////////////////////////////////////////////////// Типы вагонов
    
    public IActionResult ShowAllTypeCarriage()
    {
        var items = _typeCarriageService.GetAll();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult CreateTypeCarriage()
    {
        ViewBag.TypeCarriage = _typeCarriageService.GetAll();
        return View();
    }
    [HttpPost]
    public IActionResult CreateTypeCarriage(TypeCarriageDTO item)
    {
        ViewBag.TypeCarriage = _typeCarriageService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _typeCarriageService.Add(item);
            return RedirectToAction(nameof(ShowAllTypeCarriage));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateTypeCarriage(int id)
    {
        var item = _typeCarriageService.GetById(id);
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateTypeCarriage(TypeCarriageDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _typeCarriageService.Update(item);
            return RedirectToAction(nameof(ShowAllTypeCarriage));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteTypeCarriage(int id)
    {
        var item = _typeCarriageService.GetById(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllTypeCarriage));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteTypeCarriage(TypeCarriageDTO item)
    {
        _typeCarriageService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllTypeCarriage));
    }
    
    /////////////////////////////////////////////////// Вагоны
    
    public IActionResult ShowAllCarriages()
    {
        var items = _carriageService.GetAllWithCarTypes();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult CreateCarriage()
    {
        var carriageTypes = _typeCarriageService.GetAll();
        ViewBag.CarriageTypes = new SelectList(carriageTypes, "Id", "TypeName");
        return View();
    }
    [HttpPost]
    public IActionResult CreateCarriage(CarriageDTO item)
    {
        ViewBag.Carriage = _carriageService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _carriageService.Add(item);
            return RedirectToAction(nameof(ShowAllCarriages));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateCarriage(int id)
    {
        var item = _carriageService.GetByIdWithCarTypes(id);
        var carriageTypes = _typeCarriageService.GetAll();
        ViewBag.CarriageTypes = new SelectList(carriageTypes, "Id", "TypeName");
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateCarriage(CarriageDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _carriageService.Update(item);
            return RedirectToAction(nameof(ShowAllCarriages));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteCarriage(int id)
    {
        var item = _carriageService.GetByIdWithCarTypes(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllCarriages));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteCarriage(CarriageDTO item)
    {
        _carriageService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllCarriages));
    }
    
    /////////////////////////////////////////////////// Поезда
    
    public IActionResult ShowAllTrains()
    {
        var items = _trainService.GetAllWithTypes();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult CreateTrain()
    {
        var carriages = _carriageService.GetAll();
        ViewBag.Carriages = new SelectList(carriages, "Id", "Name");
        var trainTypes = _typeTrainService.GetAll();
        ViewBag.TrainTypes = new SelectList(trainTypes, "Id", "TypeName");
        return View();
    }
    [HttpPost]
    public IActionResult CreateTrain(TrainDTO item)
    {
        ViewBag.Carriage = _trainService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _trainService.Add(item);
            return RedirectToAction(nameof(ShowAllTrains));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateTrain(int id)
    {
        var item = _trainService.GetByIdWithTypes(id);
        var carriages = _carriageService.GetAll();
        ViewBag.Carriages = new SelectList(carriages, "Id", "Name");
        var trainTypes = _typeTrainService.GetAll();
        ViewBag.TrainTypes = new SelectList(trainTypes, "Id", "TypeName");
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateTrain(TrainDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _trainService.Update(item);
            return RedirectToAction(nameof(ShowAllTrains));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteTrain(int id)
    {
        var item = _trainService.GetByIdWithTypes(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllTrains));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteTrain(TrainDTO item)
    {
        _trainService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllTrains));
    }
    
    /////////////////////////////////////////////////// Страны

    public IActionResult ShowAllCountries()
    {
        var items = _countryService.GetAll();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult CreateCountry()
    {
        ViewBag.Country = _countryService.GetAll();
        return View();
    }
    [HttpPost]
    public IActionResult CreateCountry(CountryDTO item)
    {
        ViewBag.Country = _countryService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _countryService.Add(item);
            return RedirectToAction(nameof(ShowAllCountries));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateCountry(int id)
    {
        var item = _countryService.GetById(id);
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateCountry(CountryDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _countryService.Update(item);
            return RedirectToAction(nameof(ShowAllCountries));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteCountry(int id)
    {
        var item = _countryService.GetById(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllCountries));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteCountry(CountryDTO item)
    {
        _countryService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllCountries));
    }
    
    /////////////////////////////////////////////////// Города

    public IActionResult ShowAllCities()
    {
        var items = _cityService.GetAllWithCountry();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult CreateCity()
    {
        var countries = _countryService.GetAll();
        ViewBag.Countries = new SelectList(countries, "Id", "Name");
        return View();
    }
    [HttpPost]
    public IActionResult CreateCity(CityDTO item)
    {
        ViewBag.City = _cityService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _cityService.Add(item);
            return RedirectToAction(nameof(ShowAllCities));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateCity(int id)
    {
        var item = _cityService.GetByIdWithCountry(id);
        var countries = _countryService.GetAll();
        ViewBag.Countries = new SelectList(countries, "Id", "Name");
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateCity(CityDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _cityService.Update(item);
            return RedirectToAction(nameof(ShowAllCities));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteCity(int id)
    {
        var item = _cityService.GetByIdWithCountry(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllCities));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteCity(CityDTO item)
    {
        _cityService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllCities));
    }
    
    /////////////////////////////////////////////////// Станции

    public IActionResult ShowAllStations()
    {
        var items = _stationService.GetAllWithCity();
        return View(items);
    }
    
    [HttpGet]
    public IActionResult CreateStation()
    {
        var cities = _cityService.GetAll();
        ViewBag.Cities = new SelectList(cities, "Id", "Name");
        return View();
    }
    [HttpPost]
    public IActionResult CreateStation(StationDTO item)
    {
        ViewBag.Station = _cityService.GetAll();
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _stationService.Add(item);
            return RedirectToAction(nameof(ShowAllStations));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    [HttpGet]
    public IActionResult UpdateStation(int id)
    {
        var item = _stationService.GetByIdWithCity(id);
        var cities = _cityService.GetAll();
        ViewBag.Cities = new SelectList(cities, "Id", "Name");
        return View(item);
    }
    [HttpPost]
    public IActionResult UpdateStation(StationDTO item)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Valid";
            _stationService.Update(item);
            return RedirectToAction(nameof(ShowAllStations));
        }
        ViewBag.Message = "Non Valid";
        return View(item);
    }
    
    public IActionResult DeleteStation(int id)
    {
        var item = _stationService.GetByIdWithCity(id);
        if (item == null) 
            RedirectToAction(nameof(ShowAllStations));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteStation(StationDTO item)
    {
        _stationService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllStations));
    }
    
    /////////////////////////////////////////////////// Маршруты

    public IActionResult ShowAllRoutes()
    {
        var items = _routeService.GetAllWithAnotherData();
        return View(items);
    }

    [HttpGet]
    public IActionResult CreateRouteStop()
    {
        var stations = _stationService.GetAll();
        ViewBag.Stations = new SelectList(stations, "Id", "Name");
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateRouteStop(RouteStopViewModel rs)
    {
        var stations = _stationService.GetAll();
        ViewBag.Stations = new SelectList(stations, "Id", "Name");
        if (rs.ArrivalDate > rs.DepartureDate ||
            (rs.ArrivalDate == rs.DepartureDate && rs.ArrivalTime >= rs.DepartureTime))
        {
            ModelState.AddModelError("", "Ошибка ввода даты и времени.");
            return View(rs);
        }
        else
        {
            int index = 1;
            string json = System.IO.File.ReadAllText(pathForRoutes);
            List<RouteStopViewModel> rsmt = new List<RouteStopViewModel>();
            if (json != "")
            {
                rsmt = JsonSerializer.Deserialize<List<RouteStopViewModel>>(json);
                var oldElem = rsmt.LastOrDefault();
                if (oldElem.DepartureDate > rs.DepartureDate ||
                    oldElem.ArrivalDate > rs.ArrivalDate ||
                    (oldElem.DepartureDate == rs.DepartureDate && oldElem.DepartureTime >= rs.DepartureTime) ||
                    (oldElem.ArrivalDate == rs.ArrivalDate && oldElem.ArrivalTime >= rs.ArrivalTime))
                {
                    ModelState.AddModelError("", "Ошибка связи времени нового и старого объекта.");
                    return View(rs);
                }
                if (rsmt.Count > 0)
                {
                    index = rsmt.Count + 1;
                }
            }
            rs.SequenceNumber = index;
            rs.Station = _stationService.GetById(rs.StationId);
            rsmt.Add(rs);
            string jsonString = JsonSerializer.Serialize(rsmt);
            System.IO.File.WriteAllText(pathForRoutes, jsonString);
            return RedirectToAction(nameof(CreateRoute));   
        }
    }
    
    public IActionResult DeleteRouteStop(int id)
    {
        string json = System.IO.File.ReadAllText(pathForRoutes);
        List<RouteStopViewModel> rsmt = new List<RouteStopViewModel>();
        rsmt = JsonSerializer.Deserialize<List<RouteStopViewModel>>(json);
        var item = rsmt.Find(sm => sm.SequenceNumber == id);
        if (item == null) 
            RedirectToAction(nameof(CreateRoute));
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteRouteStop(RouteStopViewModel item)
    {
        string json = System.IO.File.ReadAllText(pathForRoutes);
        List<RouteStopViewModel> rsmt = new List<RouteStopViewModel>();
        rsmt = JsonSerializer.Deserialize<List<RouteStopViewModel>>(json);
        rsmt.RemoveAll(it => it.SequenceNumber == item.SequenceNumber);
        foreach (var it in rsmt.Where(it => it.SequenceNumber > item.SequenceNumber))
        {
            it.SequenceNumber--;
        }
        string jsonString = JsonSerializer.Serialize(rsmt);
        System.IO.File.WriteAllText(pathForRoutes, jsonString);
        return RedirectToAction(nameof(CreateRoute));
    }

    public IActionResult CreateRoute()
    {
        var trains = _trainService.GetAll();
        ViewBag.Trains = new SelectList(trains, "Id", "Name");

        
        string json = System.IO.File.ReadAllText(pathForRoutes);
        List<RouteStopViewModel> rsmt = new List<RouteStopViewModel>();
        if (json != "")
            rsmt = JsonSerializer.Deserialize<List<RouteStopViewModel>>(json);
        _combineRouteViewModel.StopModels = rsmt;
        return View(_combineRouteViewModel);
    }

    [HttpPost]
    public IActionResult CreateRoute(CombineRouteViewModel item)
    {
        string json = System.IO.File.ReadAllText(pathForRoutes);
        List<RouteStopViewModel> rsmt = new List<RouteStopViewModel>();
        if (json == "")
        {
            var trains = _trainService.GetAll();
            ViewBag.Trains = new SelectList(trains, "Id", "Name");
            ModelState.AddModelError("", "Ошибка добавления маршрута: должно быть минимум две остановки.");
            return View(_combineRouteViewModel);
        }    
        rsmt = JsonSerializer.Deserialize<List<RouteStopViewModel>>(json);
        ViewBag.Message = "Valid";
        RouteStopViewModel rs1 = rsmt.FirstOrDefault();
        RouteStopViewModel rs2 = rsmt.LastOrDefault();
        DateTime dt1 = new DateTime(rs1.ArrivalDate.Year, rs1.ArrivalDate.Month, rs1.ArrivalDate.Day, rs1.ArrivalTime.Hour, rs1.ArrivalTime.Minute, rs1.ArrivalTime.Second);
        DateTime dt2 = new DateTime(rs2.ArrivalDate.Year, rs2.ArrivalDate.Month, rs2.ArrivalDate.Day, rs2.ArrivalTime.Hour, rs2.ArrivalTime.Minute, rs2.ArrivalTime.Second);
        TimeSpan difference = dt2 - dt1;
        TimeOnly totalTime = new TimeOnly(difference.Hours, difference.Minutes, 0);
        RouteDTO route = new RouteDTO();
        route.FullRoutePrice = item.MainRoute.FullRoutePrice;
        route.TrainId = item.MainRoute.TrainId;
        route.DurationTime = totalTime;
        _routeService.Add(route);
        route = _routeService.GetAll().FirstOrDefault(r =>
            r.FullRoutePrice == route.FullRoutePrice && r.DurationTime == route.DurationTime &&
            r.TrainId == route.TrainId);
        RouteStopDTO rsdto = new RouteStopDTO();
        foreach (var it in rsmt)
        {
            rsdto.StationId = it.StationId;
            rsdto.DepartureDate = it.DepartureDate;
            rsdto.ArrivalDate = it.ArrivalDate;
            rsdto.DepartureTime = it.DepartureTime;
            rsdto.ArrivalTime = it.ArrivalTime;
            rsdto.RouteId = route.Id;
            rsdto.SequenceNumber = it.SequenceNumber;
            _routeStopService.Add(rsdto);
        }
        System.IO.File.WriteAllText(pathForRoutes, "");
        return RedirectToAction(nameof(ShowAllRoutes));
    }

    public IActionResult AboutRoute(int id)
    {
        var item = _routeService.GetAllWithAnotherData().FirstOrDefault(r => r.Id == id);
        return View(item);
    }

    public IActionResult DeleteRoute(int id)
    {
        var item = _routeService.GetAllWithAnotherData().FirstOrDefault(r => r.Id == id);
        return View(item);
    }

    [HttpPost]
    public IActionResult DeleteRoute(RouteDTO item)
    {
        foreach (var it in item.RouteStops)
        {
            _routeStopService.Delete(it.Id);
        }
        _routeService.Delete(item.Id);
        return RedirectToAction(nameof(ShowAllRoutes));
    }

    public IActionResult PopulationDiagram()
    {
        var routesData = _routeService.GetAllWithAnotherData();
        string route = "";
        PopulationDiagramViewModel pdvm = new PopulationDiagramViewModel();
        foreach (var diagram in routesData)
        {
            route = diagram.RouteStops.OrderBy(rs => rs.SequenceNumber).FirstOrDefault().Station.Name +
                    diagram.RouteStops.OrderBy(rs => rs.SequenceNumber).LastOrDefault().Station.Name;
            pdvm.countPeopleForRoute.Add(route, diagram.Tickets.Count);
        }
        return View(pdvm);
    }
}