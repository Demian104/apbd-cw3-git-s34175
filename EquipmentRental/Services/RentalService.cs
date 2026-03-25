namespace EquipmentRental.Services
{
    public class RentalService
    {
        private List<Rental> rentals = new();

        private int GetUserLimit(User user)
        {
            if (user is Student) return 2;
            if (user is Employee) return 5;
            return 1; // default
        }

        public bool Rent(Equipment equipment, User user)
        {
            if (!equipment.IsAvailable)
            {
                Console.WriteLine($"Sprzęt '{equipment.Name}' jest niedostępny!");
                return false;
            }

            int activeRentals = rentals.Count(r => r.User == user && r.ReturnDate == null);
            if (activeRentals >= GetUserLimit(user))
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} przekroczył limit wypożyczeń!");
                return false;
            }

            var rental = new Rental
            {
                Equipment = equipment,
                User = user,
                RentDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7)
            };

            rentals.Add(rental);

            equipment.IsAvailable = false;

            Console.WriteLine($"Wypożyczono sprzęt '{equipment.Name}' użytkownikowi {user.FirstName} {user.LastName}.");
            return true;
        }

        public bool Return(Equipment equipment)
        {
            var rental = rentals.FirstOrDefault(r => r.Equipment == equipment && r.ReturnDate == null);
            if (rental == null)
            {
                Console.WriteLine($"Nie znaleziono aktywnego wypożyczenia dla '{equipment.Name}'.");
                return false;
            }

            rental.ReturnDate = DateTime.Now;
            equipment.IsAvailable = true;

            if (rental.ReturnDate > rental.DueDate)
            {
                TimeSpan lateDays = rental.ReturnDate.Value.Date - rental.DueDate.Date;
                decimal fee = lateDays.Days * 5; // 5 currency units per late day
                Console.WriteLine($"Sprzęt zwrócony po terminie! Kara: {fee}.");
            }
            else
            {
                Console.WriteLine($"Sprzęt '{equipment.Name}' zwrócony w terminie.");
            }

            return true;
        }

        public List<Rental> GetAllRentals() => rentals;

        public List<Rental> GetActiveRentals() => rentals.Where(r => r.ReturnDate == null).ToList();

        public List<Rental> GetOverdueRentals() => rentals.Where(r => r.ReturnDate == null && r.DueDate < DateTime.Now).ToList();
    }
}