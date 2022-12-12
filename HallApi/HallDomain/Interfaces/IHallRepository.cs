using HallDomain.Models;

namespace HallDomain.Interfaces;

public interface IHallRepository
{
    Task<IEnumerable<Hall>> GetHallsAsync();
    Task<Hall> GetHallsByIdAsync(int id);

    Task<Hall> AddHallsAsync(Hall hall);
    Task<Hall> UpdateHallsAsync(int id, Hall hall);
    Task<Hall> DeleteHallsAsync(int id);
}
