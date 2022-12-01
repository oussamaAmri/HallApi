namespace HallDomain.Interfaces;

public interface IHallRepository
{
    Task<IEnumerable<string>> GetHallsAsync();
 //   Task<IEnumerable<string>> AddHallsAsync();
}
