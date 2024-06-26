﻿using DAL.Entities;

namespace DAL.Interfaces;

public interface IRouteRepository : IRepository<Route>
{
    public IEnumerable<Route> GetAllWithAnotherData();
}