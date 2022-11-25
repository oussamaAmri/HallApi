using HallDomain.Interfaces;

namespace HallDomain.Services;

public class HallService : IHallService
{
    public IEnumerable<string> GetHalls()
    {
        return new List<string>() { "Salle 1", "Salle 2", "Salle 3" };
    }
}
