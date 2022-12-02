using HallDomain.Models;

namespace HallDomain.Interfaces;

public interface IHallService
{
    Task<IEnumerable<Hall>> GetHallsAsync();
    Task<Hall> GetHallsByIdAsync(int id);

    Task<Hall> AddHallsAsync(Hall hall);
}
