using HallDomain.Interfaces;

namespace HallDomain.Services;

public class HallService : IHallService
{
    private readonly IHallRepository _repository;
    public IEnumerable<string> GetHalls()
    {
        return _repository.GetHalls();
    }

    public IEnumerable<string> GetPeople()
    {
        return _repository.GetPeople();
    }

    public HallService(IHallRepository hallRepository)
    {
        _repository= hallRepository;
    }
}
