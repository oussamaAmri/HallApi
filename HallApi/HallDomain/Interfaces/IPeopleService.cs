using HallDomain.Models;

namespace HallDomain.Interfaces;

public interface IPeopleService
{
    Task<IEnumerable<People>> GetPeopleAsync();
    Task<People> AddPeoplesAsync(People people);
}
