using HallDomain.Interfaces;

namespace HallDomain.Services;

public class PeopleService : IPeopleService
{
    private readonly IPeopleRepository _repository;
    public async Task<IEnumerable<string>> GetPeopleAsync()
    {
        return await _repository.GetPeopleAsync();
    }

    public PeopleService(IPeopleRepository peopleRepository)
    {
        _repository = peopleRepository;
    }
}
