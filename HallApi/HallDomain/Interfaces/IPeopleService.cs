namespace HallDomain.Interfaces;

public interface IPeopleService
{
    Task<IEnumerable<string>> GetPeopleAsync();
}
