public abstract class Equipment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
}