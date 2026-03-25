public abstract class Equipment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
}

public class Laptop : Equipment
{
    public int Ram { get; set; }
    public string Cpu { get; set; }
}

public class Camera : Equipment
{
    public int Resolution { get; set; }
    public bool HasFlash { get; set; }
}

public class Projector : Equipment
{
    public int Lumens { get; set; }
    public string Technology { get; set; }
}