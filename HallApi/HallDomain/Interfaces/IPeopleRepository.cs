namespace HallDomain.Interfaces;

public interface IPeopleRepository
{
    Task<IEnumerable<string>> GetPeopleAsync();
}
