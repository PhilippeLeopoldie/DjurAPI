using DjurAPI.DAL;

namespace DjurAPI.Models;

public class Djur
{
    public int Id { get; set; } 
    public SpeciesType Species {  get; set; }
    public double Weight { get; set; }
    public bool isFlying { get; set; }

    public string Specie => Species.ToString();
}
