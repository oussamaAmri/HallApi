namespace HallDal;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string FullName { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
