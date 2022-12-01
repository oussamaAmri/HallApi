using HallDomain.Interfaces;

namespace HallDomain.Services;

public class HallService : IHallService
{
    private readonly IHallRepository _repository;
    public async Task<IEnumerable<string>> GetHallsAsync()
    {
        return await _repository.GetHallsAsync();
    }
/*    public async Task<IEnumerable<string>> AddHallsAsync()
    {
        return await _repository.AddHallsAsync();
    }
*/
    public IEnumerable<string> GetPeople()
    {
        throw new NotImplementedException();
    }

    public HallService(IHallRepository hallRepository)
    {
        _repository = hallRepository;
    }
}
