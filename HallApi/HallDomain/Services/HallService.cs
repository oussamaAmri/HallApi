using HallDomain.Interfaces;
using HallDomain.Models;

namespace HallDomain.Services;

public class HallService : IHallService
{
    private readonly IHallRepository _repository;
    public async Task<IEnumerable<Hall>> GetHallsAsync()
    {
        return await _repository.GetHallsAsync();
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
