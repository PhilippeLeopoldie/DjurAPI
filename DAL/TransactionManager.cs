using DjurAPI.Data;
using DjurAPI.DTOs;
using DjurAPI.Entities;
using DjurAPI.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DjurAPI.DAL;

public class TransactionManager
{
    private readonly DjurContext _context;

    public TransactionManager(DjurContext context)
    {
        _context = context;
    }
    public async Task<List<Djur>> GetDjurAsync()
    {
        return await _context.Djur.ToListAsync();
    }

    public async Task<Djur?> GetDjurByIdAsync(int id)
    {
        return await _context.Djur.FindAsync(id);
    }

    public async Task UpdateDjur(int id, DjurDtoRequest dto)
    {
        var djur = await GetDjurByIdAsync(id);
        if (djur != null)
        {
            djur.isFlying = dto.IsFlying;
            djur.Weight = dto.Weight;
            djur.Species = dto.Species;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception($"Djur with Id:{id} not found!");
        }
        
        
    }

    public  async Task CreateDjurAsync(DjurDtoRequest djur)
    {
        _context.Add(new Djur
        {
            isFlying = djur.IsFlying,
            Weight = djur.Weight,
            Species = djur.Species
        });
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDjurAsync(int id)
    {
        var djur = GetDjurByIdAsync(id);
        _context.Remove(djur);
    }

   /* private  SpeciesType ConvertDjurNameToEnum( string name)
    {
        if (Enum.TryParse<SpeciesType>(name, out var species))
        {
            return species;
        }
        else
        {
            throw new ArgumentException($"Invalid species name: {name}");
        }
    }*/

   
}
