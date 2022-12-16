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

    public async Task<IEnumerable<Booking>> GetReservationsAsync()
    {
        return await _dbContext.Bookings.Select(b => new Booking
        {
            Id = b.Id,
            StartSlot = b.StartSlot,
            EndSlot = b.EndSlot
        }).ToListAsync();
    }
}
