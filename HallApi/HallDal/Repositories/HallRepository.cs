﻿using HallDal.Entities;
using HallDomain.Interfaces;
using HallDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace HallDal.Repositories
{
    public class HallRepository : IHallRepository
    {
        private readonly FuwearContext _dbContext;

        public HallRepository(FuwearContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        //public IEnumerable<string> GetHalls()
        //{
        //    //var db = _dbContext.Rooms.ToList();
        //    //var rooms = new List<string>();
        //    //foreach (var room in db)
        //    //{
        //    //    rooms.Add(room.RoomName);
        //    //}

        //    return _dbContext.Rooms.Select(r => r.RoomName).ToList();
        //}

        //public async Task<IEnumerable<string>> GetHallsAsync()
        //{
        //    //var db = _dbContext.Rooms.ToList();
        //    //var rooms = new List<string>();
        //    //foreach (var room in db)
        //    //{
        //    //    rooms.Add(room.RoomName);
        //    //}

        //    return await _dbContext.Rooms.Select(r => r.RoomName).ToListAsync();
        //}

        public async Task<IEnumerable<Hall>> GetHallsAsync()
        {
            return await _dbContext.Rooms.Select(r => new Hall
            {
                Id = r.Id,
                Name = r.RoomName
            }).ToListAsync();
        }

        public async Task<Hall> AddHallsAsync(Hall hall)
        {
            var room = new RoomEntity { RoomName = hall.Name };
            var db = _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
            return new Hall { Id=room.Id, Name = room.RoomName };
             
        }
    }
}
