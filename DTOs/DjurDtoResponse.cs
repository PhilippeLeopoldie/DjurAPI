using DjurAPI.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DjurAPI.DTOs
{
    public record DjurDtoResponse
    {
        public int Id { get; init; }
        [JsonIgnore]
        public SpeciesType SpeciesName { get; init; }

        public double Weight { get; init; }
        public bool isFlying { get; init; }
        [Display(Name = "Species")]
        public string SpeciesDisplayName => SpeciesName.ToString();
    }
}
