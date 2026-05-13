using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTOs;

public class GetComponentDto
{
    [MaxLength(10)]
    public string Code { get; set; } = string.Empty;
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public GetComponentManufacturerDto GetComponentManufacturerDto { get; set;}
    public GetComponentTypeDto GetComponentTypeDto { get; set;}
    
}