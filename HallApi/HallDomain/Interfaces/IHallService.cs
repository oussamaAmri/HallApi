using HallDomain.Models;

namespace HallDomain.Interfaces;

public interface IHallService
{
    Task<IEnumerable<Hall>> GetHallsAsync();
    Task<IEnumerable<string>> AddHallsAsync();
}
