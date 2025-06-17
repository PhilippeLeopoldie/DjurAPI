using DjurAPI.DAL;
using DjurAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DjurAPI.Entities;

public class Djur
{
    public Guid Id { get; set; }
    public SpeciesType Species {  get; set; }
    public double Weight { get; set; }
    public bool isFlying { get; set; }

    public string SpeciesDisplayName => Species.ToString();
}
