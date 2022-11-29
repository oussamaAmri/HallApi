using System;
using System.Collections.Generic;

namespace HallDal;

public partial class Room
{
    public int Id { get; set; }

    public string RoomName { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
