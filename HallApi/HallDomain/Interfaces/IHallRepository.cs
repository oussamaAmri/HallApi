namespace HallDomain.Interfaces;

public interface IHallRepository
{
    Task<IEnumerable<string>> GetHallsAsync();
}
