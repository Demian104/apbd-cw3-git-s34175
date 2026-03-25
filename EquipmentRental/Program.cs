using EquipmentRental.Services;

var service = new RentalService();

var laptop = new Laptop { Name = "Dell", Ram = 16, Cpu = "i7" };
var student = new Student { FirstName = "Jan", LastName = "Kowalski" };

service.Rent(laptop, student);
service.Return(laptop);