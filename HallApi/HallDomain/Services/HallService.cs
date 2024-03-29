﻿using HallDomain.Interfaces;
using HallDomain.Models;

namespace HallDomain.Services;

public class HallService : IHallService
{
    private readonly IHallRepository _repository;
    public async Task<IEnumerable<Hall>> GetHallsAsync()
    {
        return await _repository.GetHallsAsync();
    }
    public async Task<Hall> GetHallsByIdAsync(int id)
    {
        return await _repository.GetHallsByIdAsync(id);
    }
    public async Task<Hall> AddHallsAsync(Hall hall)
    {
        return await _repository.AddHallsAsync(hall);
    }
    public async Task<Hall> UpdateHallsAsync(int id, Hall hall)
    {
        return await _repository.UpdateHallsAsync(id, hall);
    }
    public async Task<Hall> DeleteHallsAsync(int id)
    {
        return await _repository.DeleteHallsAsync(id);
    }
    public IEnumerable<string> GetPeople()
    {
        throw new NotImplementedException();
    }

    public HallService(IHallRepository hallRepository)
    {
        _repository = hallRepository;
    }
}
