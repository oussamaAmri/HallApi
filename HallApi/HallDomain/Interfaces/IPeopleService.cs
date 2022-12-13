using HallDomain.Models;

namespace HallDomain.Interfaces;

public interface IPeopleService
{
    Task<IEnumerable<People>> GetPeopleAsync();
    Task<People> GetPeopleByIdAsync(int id);
    Task<People> AddPeoplesAsync(People people);
    Task<People> UpdatePeoplesAsync(int id,People people);
    Task<People> DeletePeoplesAsync(int id);
}
