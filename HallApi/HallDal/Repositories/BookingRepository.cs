using HallDal.Entities;
using HallDomain.Interfaces;
using HallDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace HallDal.Repositories;
public class BookingRepository : IBookingRepository
{
    private readonly FuwearContext _dbContext;

    public BookingRepository(FuwearContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    public async Task<Booking> AddReservationAsync(Booking reservation)
    {
        var booking = new BookingEntity { Id = reservation.Id, RoomId = reservation.RoomId, PersonId = reservation.PersonId, BookingDate = reservation.BookingDate, StartSlot = reservation.StartSlot, EndSlot = reservation.EndSlot };
        var db = _dbContext.Bookings.Add(booking);
        await _dbContext.SaveChangesAsync();
        return new Booking { Id = booking.Id, RoomId = booking.RoomId, PersonId = booking.PersonId, BookingDate = booking.BookingDate, StartSlot = booking.StartSlot, EndSlot = booking.EndSlot };
    }

    public async Task<IEnumerable<Booking>> GetReservationByRommAndByDate(int roomId, DateTime date)
    {
        return await _dbContext.Bookings.
            Where(b=> b.RoomId == roomId && b.BookingDate.Date == date.Date).
            Select(b => new Booking
        {
            Id = b.Id,
            RoomId = b.RoomId,
            PersonId = b.PersonId,
            BookingDate = b.BookingDate,
            StartSlot = b.StartSlot,
            EndSlot = b.EndSlot

        }).OrderBy(b=>b.StartSlot).ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetReservationsAsync()
    {
        return await _dbContext.Bookings.Select(b => new Booking
        {
            Id = b.Id,
            RoomId = b.RoomId,
            PersonId = b.PersonId,
            BookingDate = b.BookingDate,
            StartSlot = b.StartSlot,
            EndSlot = b.EndSlot
        }).ToListAsync();
    }

  /*  public async Task<Booking> GetReservationByIdAsync(int id)
    {
        var booking = await _dbContext.Bookings.SingleOrDefaultAsync(r => r.Id == id);
        if (booking == null)
        {
            return null;
        }
        return new Booking { Id = booking.Id, RoomId = booking.RoomId, PersonId = booking.PersonId, BookingDate = booking.BookingDate, StartSlot = booking.StartSlot, EndSlot = booking.EndSlot };
    }*/
}
