using DjurAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;


namespace DjurAPI.DTOs;

public record DjurDtoRequest
{
    public Guid Id { get; set; }
    [Required]
    [EnumDataType(typeof(SpeciesType), ErrorMessage ="Invalide species")]
    [Display(Name ="Species", Description ="1:Cat, 2:Fish, 3:Bird")]
    public SpeciesType Species { get; set; }
    public double Weight { get; set; }
    public bool IsFlying { get; set; }

}
