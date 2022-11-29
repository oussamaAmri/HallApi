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
        throw new NotImplementedException();
    }

    public HallService(IHallRepository hallRepository)
    {
        _repository = hallRepository;
    }
}
