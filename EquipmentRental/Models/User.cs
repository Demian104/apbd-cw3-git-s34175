public abstract class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Student : User
{
}

public class Employee : User
{
}