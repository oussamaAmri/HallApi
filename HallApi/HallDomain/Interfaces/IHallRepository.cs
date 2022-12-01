using HallDomain.Models;

namespace HallDomain.Interfaces;

public interface IHallRepository
{
    Task<IEnumerable<Hall>> GetHallsAsync();
    Task<IEnumerable<string>> AddHallsAsync();
}
