using DjurAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;


namespace DjurAPI.DTOs;

public class DjurDtoRequest
{
    public Guid Id { get; set; }
    [Required]
    [EnumDataType(typeof(SpeciesType), ErrorMessage ="Invalide species")]
    [Display(Name ="Species")]
    public SpeciesType SpeciesName { get; set; }

    public double Weight { get; set; }
    public bool isFlying { get; set; }

}
