using HallDal.Entities;
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

        public async Task<Hall> GetHallsByIdAsync(int id)
        {
            var rooms = await _dbContext.Rooms.SingleOrDefaultAsync(r => r.Id == id);
            if (rooms == null)
            {
                return null;
            }
                return new Hall { Id = rooms.Id, Name =rooms.RoomName};
        }

        public async Task<Hall> AddHallsAsync(Hall hall)
        {
            var room = new RoomEntity { RoomName = hall.Name };
            var db = _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
            return new Hall { Id=room.Id, Name = room.RoomName };
             
        }

        public async Task<Hall> UpdateHallsAsync(int id, Hall hall)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            var roomToUpdate = new RoomEntity { RoomName = hall.Name};
            if (room == null)
            {
                return null;
            }
            room.RoomName = roomToUpdate.RoomName;
            await _dbContext.SaveChangesAsync();
            return new Hall { Id = room.Id, Name = room.RoomName};
        }
        public async Task<Hall> DeleteHallsAsync(int id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
            return new Hall { Id = room.Id, Name = room.RoomName};
        }
    }
}
