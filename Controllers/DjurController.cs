using DjurAPI.DTOs;
using DjurAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DjurAPI.Controllers;

[ApiController]
[Route("api/Djurs")]
public class DjurController(DAL.TransactionManager transaction) : ControllerBase
{

    [HttpGet]
    public async Task<List<DjurDto>> GetDjursAsync()
    {
        var result = await transaction.GetDjurAsync();
        return result.Select(djur => new DjurDto
        {
            Id = djur.Id,
            isFlying = djur.isFlying,
            SpeciesName = djur.SpeciesDisplayName,
            Weight = djur.Weight
        }).ToList();
    }

    [HttpGet("{id}")]
    public async Task<Djur> GetDjurByIdAsync(int id)
    {
        return await transaction.GetDjurByIdAsync(id);
    }

    [HttpPut("{id}")]
    public async Task PutDjur(int id, [FromQuery] DjurDto dto)
    {
        try
        {
            await transaction.UpdateDjur(id, dto);
        }
        catch(Exception ex)
        {
            BadRequest(ex);
        }
        
    }

    [HttpPost]
    public async Task CreateDjur([FromQuery] DjurDto djur)
    {
        await transaction.CreateDjurAsync(djur);
    }

    [HttpDelete("{id}")]
    public async Task DeleteDjur(int id)
    {
        try
        {
            await transaction.DeleteDjurAsync(id);
        }
        catch(Exception ex)
        {
            BadRequest(ex);
        }
    }


   

}
