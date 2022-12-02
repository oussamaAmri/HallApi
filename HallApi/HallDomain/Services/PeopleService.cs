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
    public async Task<People> AddPeoplesAsync(People people)
    {
        return await _repository.AddPeoplesAsync(people);
    }

    public PeopleService(IPeopleRepository peopleRepository)
    {
        _repository = peopleRepository;
    }
}
