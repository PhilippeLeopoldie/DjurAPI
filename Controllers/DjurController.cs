using DjurAPI.DTOs;
using DjurAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DjurAPI.Controllers;

[ApiController]
[Route("api/Djurs")]
public class DjurController(DAL.TransactionManager transaction): ControllerBase
{

    [HttpGet]
    public async Task<List<DjurDto>> GetDjursAsync()
    {
        var result = await transaction.GetDjurAsync();
        return result.Select(djur => new DjurDto
        {
            Id = djur.Id,
            isFlying = djur.isFlying,
            Species = djur.Specie,
            Weight = djur.Weight
        }).ToList();
    }

    [HttpGet("{id}")]
    public async Task<Djur> GetDjurByIdAsync(int id)
    {
        return await transaction.GetDjurByIdAsync(id);   
    }



   

}
