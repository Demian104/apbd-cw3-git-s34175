public class Rental
{
    public Equipment Equipment { get; set; }
    public User User { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}