using HallDomain.Models;

namespace HallDomain.Interfaces;

public interface IHallService
{
    Task<IEnumerable<Hall>> GetHallsAsync();

    Task<Hall> AddHallsAsync(Hall hall);
}
