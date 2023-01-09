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
            Bookings = booking.Select(b=> new Dtos.BookingDto
            {
                Id = b.Id,
                BookingDate = b.BookingDate,
                StartSlot = b.StartSlot,
                EndSlot = b.EndSlot
            })
        });
    }

/*    [HttpGet("Booking/{id}")]
    public async Task<IActionResult> GetReservationByIdAsync([FromRoute] int id)
    {
        var reservation = await _bookingService.GetReservationByIdAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }

        return Ok(new BookingResponse
        {
            reservation = new BookingDto { Id  = , Name = hall.Name }
        });
    }
*/
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
}