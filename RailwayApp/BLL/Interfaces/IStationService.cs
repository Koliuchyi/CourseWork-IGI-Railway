﻿using BLL.DTO;
using DAL.Entities;

namespace BLL.Interfaces;

public interface IStationService : IService<StationDTO>
{
    public IEnumerable<StationDTO> GetAllWithCity();
    public StationDTO GetByIdWithCity(int id);
}