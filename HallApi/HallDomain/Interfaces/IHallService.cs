namespace HallDomain.Interfaces;

public interface IHallService
{
    Task<IEnumerable<string>> GetHallsAsync();
    //IEnumerable<string> GetPeople();
}
