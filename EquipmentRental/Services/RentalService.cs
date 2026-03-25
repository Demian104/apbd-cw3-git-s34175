public class RentalService
{
    private List<Rental> rentals = new();

    public void Rent(Equipment equipment, User user)
    {
        if (!equipment.IsAvailable)
        {
            Console.WriteLine("Sprzęt niedostępny!");
            return;
        }

        equipment.IsAvailable = false;

        rentals.Add(new Rental
        {
            Equipment = equipment,
            User = user,
            RentDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(7)
        });
    }

    public void Return(Equipment equipment)
    {
        var rental = rentals.FirstOrDefault(r => r.Equipment == equipment && r.ReturnDate == null);

        if (rental == null) return;

        rental.ReturnDate = DateTime.Now;
        equipment.IsAvailable = true;
    }
}