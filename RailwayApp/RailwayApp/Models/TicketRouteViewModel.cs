using BLL.DTO;

namespace RailwayApp.Models;

public class TicketRouteViewModel
{
    public TicketDTO ticket { get; set; }
    public RouteDTO route { get; set; }

    public TicketRouteViewModel()
    {
        
    }
    public TicketRouteViewModel(TicketDTO t, RouteDTO r)
    {
        ticket = t;
        route = r;
    }
}