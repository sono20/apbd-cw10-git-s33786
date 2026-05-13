using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTOs;

public class PCComponentDto
{
    [MaxLength(10)] 
    public string ComponentCode { get; set; } = String.Empty;
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; }
}