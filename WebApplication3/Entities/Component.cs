namespace WebApplication3.Entities;

public class Component
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ComponentManufacturerId { get; set; }
    public int ComponentTypeId { get; set; }
    
    public virtual ComponentManufacturer ComponentManufacturer { get; set; }
    public virtual ComponentType ComponentType { get; set; }

    public ICollection<PCComponent> PCComponents { get; set; } = [];
}