using HallDomain.Interfaces;

namespace HallDomain.Services;

public class PeopleService : IPeopleService
{
    private readonly IPeopleRepository _repository;
    public IEnumerable<string> GetPeople()
    {
        return _repository.GetPeople();
    }

    public PeopleService(IPeopleRepository peopleRepository)
    {
        _repository = peopleRepository;
    }
}
