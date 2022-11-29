namespace HallDomain.Interfaces;

public interface IPeopleRepository
{
    IEnumerable<string> GetPeople();
}
