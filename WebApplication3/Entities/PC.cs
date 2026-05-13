namespace WebApplication3.Entities;

public class PC
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    
    public ICollection<PCComponent> PcComponents { get; set; } = [];
}