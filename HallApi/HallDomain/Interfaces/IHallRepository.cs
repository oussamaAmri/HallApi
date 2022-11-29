namespace HallDomain.Interfaces;

public interface IHallRepository
{
    IEnumerable<string> GetHalls();
}
