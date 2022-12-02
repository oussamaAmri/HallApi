using HallDomain.Models;

namespace HallDomain.Interfaces;

public interface IPeopleRepository
{
    Task<IEnumerable<People>> GetPeopleAsync();
    Task<People> AddPeoplesAsync(People people);
}