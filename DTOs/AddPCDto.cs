using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTOs;

public class AddPCDto
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public GetAllComponentsDto GetAllComponentsDto { get; set; }
}