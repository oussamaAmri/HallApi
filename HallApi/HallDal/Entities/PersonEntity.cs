﻿namespace HallDal.Entities;

public partial class PersonEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<BookingEntity> Bookings { get; } = new List<BookingEntity>();
}
