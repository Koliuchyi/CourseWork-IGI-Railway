using System.Text.Json;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using RailwayApp.Models;

namespace RailwayApp.Controllers;

public class ClientController : Controller
{
    private string pathForClients =
        "E:\\Учёба Университет\\ИГИ\\Курсовая работа\\RailwayApp\\RailwayApp\\ClientData.json";
    private IStationService _stationService;
    private ICountryService _countryService;
    private ITrainService _trainService;
    private INewsTableService _newsTableService;
    private IRouteStopService _routeStopService;
    private ITicketService _ticketService;
    private IRouteService _routeService;
    private IClientService _clientService;
    
    public ClientController(INewsTableService newsTableService, ITrainService trainService, ICountryService countryService,
        IStationService stationService, IRouteStopService routeStopService, IRouteService routeService, IClientService clientService,
        ITicketService ticketService)
    {
        _stationService = stationService;
        _newsTableService = newsTableService;
        _trainService = trainService;
        _countryService = countryService;
        _routeStopService = routeStopService;
        _routeService = routeService;
        _clientService = clientService;
        _ticketService = ticketService;
    }
    public IActionResult Index(int id)
    {
        var json = JsonSerializer.Serialize(id);
        System.IO.File.WriteAllText(pathForClients, json);
        var news = _newsTableService.GetAll();
        var stations = _stationService.GetAll();
        ViewBag.Stations = new SelectList(stations, "Id", "Name");
        return View(news);
    }

    [HttpPost]
    public IActionResult Index(string DepartureName, string ArrivalName, DateOnly DateRoute)
    {
        if (DepartureName.IsNullOrEmpty() || ArrivalName.IsNullOrEmpty())
        {
            var news = _newsTableService.GetAll();
            var stations = _stationService.GetAll();
            ViewBag.Stations = new SelectList(stations, "Id", "Name");
            ViewBag.ErrorMessage = "Произошла ошибка! Пожалуйста, повторите попытку.";
            return View(news);
        }
        else
        {
            var departureStation = _stationService.GetAll().FirstOrDefault(s => s.Id == int.Parse(DepartureName));
            var arrivalStation = _stationService.GetAll().FirstOrDefault(s => s.Id == int.Parse(ArrivalName));
            
            var departureRouteStops = _routeStopService.GetAll().Where(rs => rs.StationId == departureStation.Id && rs.DepartureDate == DateRoute);
            var arrivalRouteStops = _routeStopService.GetAll().Where(rs => rs.StationId == arrivalStation.Id);
            if (departureRouteStops.Count() == 0 || arrivalRouteStops.Count() == 0)
            {
                var news = _newsTableService.GetAll();
                var stations = _stationService.GetAll();
                ViewBag.Stations = new SelectList(stations, "Id", "Name");
                ViewBag.ErrorMessage = "Произошла ошибка! Пожалуйста, повторите попытку.";
                return View(news);
            }
            var commonRoutes = departureRouteStops.Join(
                    arrivalRouteStops,
                    departure => departure.RouteId,
                    arrival => arrival.RouteId,
                    (departure, arrival) => departure.RouteId)
                .ToList();
            var json = JsonSerializer.Serialize(commonRoutes);
            TempData["CommonRoutes"] = json;
            return RedirectToAction(nameof(ShowAllNeedRoutes), new { DepartureName = departureStation.Name, ArrivalName = arrivalStation.Name});
        }
    }

    public IActionResult ShowAllNeedRoutes(string DepartureName, string ArrivalName)
    {
        var IDs = TempData["CommonRoutes"] as string;
        var needIdsInt = JsonSerializer.Deserialize<List<int>>(IDs);
        var cr = _routeService.GetAllWithAnotherData().Where(obj => needIdsInt.Contains(obj.Id)).ToList();
        var allNeedRoutes = _routeService.GetAllWithAnotherData();
        var anr = allNeedRoutes    
            .Where(r => cr.Select(n => n.Id).Contains(r.Id));
        OwnClientRouteViewModel ocrvm = new OwnClientRouteViewModel(anr, DepartureName, ArrivalName); 
        return View(ocrvm);
    }

    public IActionResult AboutRoute(int id, string DepartureName, string ArrivalName)
    {
        var myRoute = _routeService.GetAllWithAnotherData().FirstOrDefault(r => r.Id == id);
        return View(myRoute);
    }

    public IActionResult BookingRoute(int id, string DepartureName, string ArrivalName)
    {
        var myRoute = _routeService.GetAllWithAnotherData().FirstOrDefault(r => r.Id == id);
        var CountPlaces = myRoute.Train.CarriageCount * myRoute.Train.Carriage.PlacesCount;
        if (myRoute.Tickets.Count() == CountPlaces)
        {
            ViewBag.Message = "Кажется, все билеты на поезд уже забронированы.";
        }
        else
        {
            var json = System.IO.File.ReadAllText(pathForClients);
            ClientDTO client = _clientService.GetById(JsonSerializer.Deserialize<int>(json));
            Random random = new Random();
            ViewBag.Message = "Бронирование успешно выполнено.";
            TicketDTO ticket = new TicketDTO();
            ticket.RouteId = myRoute.Id;
            ticket.TicketPrice = (myRoute.FullRoutePrice / myRoute.RouteStops.LastOrDefault().SequenceNumber) * myRoute.RouteStops.FirstOrDefault(s => s.Station.Name == ArrivalName).SequenceNumber;
            ticket.DepartureStation = DepartureName;
            ticket.ArrivalStation = ArrivalName;
            ticket.SeatNumber = random.Next(1, myRoute.Train.CarriageCount * myRoute.Train.Carriage.PlacesCount);
            ticket.ClientId = client.Id;
            _ticketService.Add(ticket);
        }
        return View();
    }

    public IActionResult ShowMyBagRoutes()
    {
        var json = System.IO.File.ReadAllText(pathForClients);
        ClientDTO client = _clientService.GetById(JsonSerializer.Deserialize<int>(json));
        var ticket = _ticketService.GetAll().FirstOrDefault(t => t.ClientId == client.Id);
        TicketRouteViewModel trvm = null;
        if (ticket == null)
            ViewBag.Message = "На данный момент корзина пуста.";
        else
        {
            var myRoute = _routeService.GetAllWithAnotherData().FirstOrDefault(r => r.Id == ticket.RouteId);
            trvm = new TicketRouteViewModel(ticket, myRoute);
        }
        return View(trvm);
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
}