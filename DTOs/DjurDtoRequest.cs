using DjurAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;


namespace DjurAPI.DTOs;

public class DjurDtoRequest
{
    public int Id { get; set; }
    [EnumDataType(typeof(SpeciesType), ErrorMessage ="Invalide species")]
    public SpeciesType SpeciesName { get; set; }
    public double Weight { get; set; }
    public bool isFlying { get; set; }

}
