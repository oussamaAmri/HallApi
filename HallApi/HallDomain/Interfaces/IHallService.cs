namespace HallDomain.Interfaces;

public interface IHallService
{
    Task<IEnumerable<string>> GetHallsAsync();
//    Task<IEnumerable<string>> AddHallsAsync();
}
