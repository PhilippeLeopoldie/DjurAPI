using DjurAPI.Models;

namespace DjurAPI.DTOs;

public class DjurDto
{
    public int Id { get; set; }
    public string? Species { get; set; }
    public double Weight { get; set; }
    public bool isFlying { get; set; }

}
