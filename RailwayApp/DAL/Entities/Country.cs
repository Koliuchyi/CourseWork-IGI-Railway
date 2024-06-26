﻿namespace DAL.Entities;

public class Country
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Photo { get; set; }
    public List<City> Cities { get; set; } = new();
}