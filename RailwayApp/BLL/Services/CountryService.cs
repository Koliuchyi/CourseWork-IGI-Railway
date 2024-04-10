using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class CountryService : ICountryService
{
    ICountryRepository Database { get; set; }
    IMapper _mapper;
    
    public CountryService(ICountryRepository db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<CountryDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Country>, List<CountryDTO>>(Database.GetAll());
    }

    public CountryDTO GetById(int id)
    {
        return _mapper.Map<Country, CountryDTO>(Database.GetById(id));
    }

    public void Add(CountryDTO entity)
    {
        Database.AddEntity(_mapper.Map<Country>(entity));
    }

    public void Update(CountryDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<Country>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}