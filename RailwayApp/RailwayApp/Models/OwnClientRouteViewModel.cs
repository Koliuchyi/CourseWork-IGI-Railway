using System.ComponentModel.DataAnnotations;
using BLL.DTO;

namespace RailwayApp.Models;

public class OwnClientRouteViewModel
{
    public IEnumerable<RouteDTO> _needRoutes { get; set; }
    public string _DepartureName { get; set; }
    public string _ArrivalName { get; set; }

    public OwnClientRouteViewModel(IEnumerable<RouteDTO> needRoutes, string departureName, string arrivalName)
    {
        _needRoutes = needRoutes;
        _DepartureName = departureName;
        _ArrivalName = arrivalName;
    }
}