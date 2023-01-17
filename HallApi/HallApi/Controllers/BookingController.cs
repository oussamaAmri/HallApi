using HallApi.Dtos;
using HallApi.Dtos.Requests;
using HallApi.Dtos.Responses;
using HallDomain.Interfaces;
using HallDomain.Models;
using HallDomain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HallApi.Controllers;

[Route("api")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet("Booking")]
    public async Task<IActionResult> GetReservationsAsync()
    {
        IEnumerable<Booking> booking = await _bookingService.GetReservationsAsync();
        return Ok(new BookingsResponse
        {
            Bookings = booking.Select(b => new Dtos.BookingDto
            {
                Id = b.Id,
                RoomId = b.RoomId,
                PersonId = b.PersonId,
                BookingDate = b.BookingDate,
                StartSlot = b.StartSlot,
                EndSlot = b.EndSlot
            })
        });
    }
    [HttpGet("Booking/{roomId}")]
    public async Task<IActionResult> GetReservationByIdAsync([FromRoute] int roomId)
    {
        IEnumerable<Booking> booking = await _bookingService.GetReservationByIdAsync(roomId);
        return Ok(new BookingsResponse
        {
            Bookings = booking.Select(b => new Dtos.BookingDto
            {
                Id = b.Id,
                RoomId = b.RoomId,
                PersonId = b.PersonId,
                BookingDate = b.BookingDate,
                StartSlot = b.StartSlot,
                EndSlot = b.EndSlot
            })
        });
    }

    [HttpPost("booking")]
    public async Task<IActionResult> AddReservationAsync([FromBody] CreateBookingRequest createBookingRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var reservation = new Booking();
        reservation.RoomId = createBookingRequest.RoomId;
        reservation.PersonId = createBookingRequest.PersonId;
        reservation.BookingDate = createBookingRequest.BookingDate;
        reservation.StartSlot = createBookingRequest.StartSlot;
        reservation.EndSlot = createBookingRequest.EndSlot;
        var addBooking = await _bookingService.AddReservationAsync(reservation);
        var responseUsers = new BookingResponseUsers();
        responseUsers.message = addBooking.ErrorMSG.ToList();
        if(addBooking.booking != null)
        {
            responseUsers.infoReservation = new BookingDto { Id = addBooking.booking.Id, RoomId = addBooking.booking.RoomId, PersonId = addBooking.booking.PersonId, BookingDate = addBooking.booking.BookingDate, StartSlot = addBooking.booking.StartSlot, EndSlot = addBooking.booking.EndSlot };
        }
        
        responseUsers.listesCreneux = addBooking?.ListReservation.Select(i=>new SlotDto { startSlot=i.startSlot, endSlot=i.endSlot });
        return Ok(addBooking); 
    }
    [HttpDelete("Booking/{id}")]
    public async Task<IActionResult> DeleteBookingsAsync([FromRoute] int id)
    {
        var booking = await _bookingService.DeleteBookingsAsync(id);
        if (booking == null)
        {
            return NotFound();
        }
        return Ok(new BookingResponse
        {
            booking = new Dtos.BookingDto { Id = booking.Id, PersonId = booking.PersonId, RoomId = booking.RoomId,BookingDate=booking.BookingDate,StartSlot=booking.StartSlot,EndSlot=booking.EndSlot}
        });
    }

    [HttpPost("booking/search")]
    public async Task<IActionResult> GetReservationByRommAndByDate([FromBody] SearchBookingRequeste searchBookingRequeste)
    {
        SearchBooking searchBooking = new SearchBooking();
        searchBooking.RoomId = searchBookingRequeste.RoomId;
        searchBooking.Date = searchBookingRequeste.Date;
        var booking = await _bookingService.GetReservationByRommAndByDate(searchBooking);
        return Ok(new BookingsResponse
        {
            Bookings = booking.Select(b => new Dtos.BookingDto
            {
                Id = b.Id,
                RoomId = b.RoomId,
                PersonId = b.PersonId,
                BookingDate = b.BookingDate,
                StartSlot = b.StartSlot,
                EndSlot = b.EndSlot
            })
        });
    }
}