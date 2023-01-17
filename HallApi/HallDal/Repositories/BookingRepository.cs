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

    public async Task<IEnumerable<Booking>> GetReservationByRommAndByDate(SearchBooking searchBooking)
    {
        return await _dbContext.Bookings.
            Where(b=> b.RoomId == searchBooking.RoomId && b.BookingDate.Date == searchBooking.Date.Date).
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

    public async Task<IEnumerable<Booking>> GetReservationByIdAsync(int roomId)
    {
        return await _dbContext.Bookings.
            Where(b => b.RoomId == roomId).
            Select(b => new Booking
            {
                Id = b.Id,
                RoomId = b.RoomId,
                PersonId = b.PersonId,
                BookingDate = b.BookingDate,
                StartSlot = b.StartSlot,
                EndSlot = b.EndSlot

            }).ToListAsync();
    }

    public async Task<Booking> DeleteBookingsAsync(int id)
    {
        var booking = await _dbContext.Bookings.FindAsync(id);
        if (booking == null)
        {
            return null;
        }
        _dbContext.Bookings.Remove(booking);
        await _dbContext.SaveChangesAsync();
        return new Booking { Id = booking.Id, PersonId = booking.PersonId,RoomId=booking.RoomId,BookingDate=booking.BookingDate,StartSlot=booking.StartSlot,EndSlot=booking.EndSlot};
    }
}
