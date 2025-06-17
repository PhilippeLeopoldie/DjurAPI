using DjurAPI.Data;
using DjurAPI.DTOs;
using DjurAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DjurAPI.DAL;

public  class TransactionManager(DjurContext context)
{
    public async Task<List<Djur>> GetDjurAsync()
    {
        return await context.Djur.ToListAsync();
    }

    public async Task<Djur?> GetDjurByIdAsync(int id)
    {
        return await context.Djur.FindAsync(id);
    }

    public async Task UpdateDjur(int id, DjurDto dto)
    {
        var djur = await GetDjurByIdAsync(id);
        if (djur != null)
        {
            djur.isFlying = dto.isFlying;
            djur.Weight = dto.Weight;
            if (Enum.TryParse<SpeciesType>(dto.SpeciesName, out var species))
            {
                djur.Species = species;
            }
            else
            {
                throw new ArgumentException($"Invalid species name: {dto.SpeciesName}");
            }     
        }
        await context.SaveChangesAsync();
        
    }
}
