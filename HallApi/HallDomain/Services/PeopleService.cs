using HallDomain.Interfaces;
using HallDomain.Models;

namespace HallDomain.Services;

public class PeopleService : IPeopleService
{
    private readonly IPeopleRepository _repository;
    public async Task<IEnumerable<People>> GetPeopleAsync()
    {
        return await _repository.GetPeopleAsync();
    }
    public async Task<People> GetPeopleByIdAsync(int id)
    {
        return await _repository.GetPeopleByIdAsync(id);
    }
    public async Task<People> AddPeoplesAsync(People people)
    {
        return await _repository.AddPeoplesAsync(people);
    }

    public async Task<People> UpdatePeoplesAsync(int id,People people)
    {
        return await _repository.UpdatePeoplesAsync(id,people);
    }

    public PeopleService(IPeopleRepository peopleRepository)
    {
        _repository = peopleRepository;
    }
}
