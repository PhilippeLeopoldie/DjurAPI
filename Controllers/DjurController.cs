using DjurAPI.DTOs;
using DjurAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DjurAPI.Controllers;

[ApiController]
[Route("api/Djurs")]
public class DjurController(DAL.TransactionManager transaction) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DjurDtoResponse>>> GetDjursAsync()
    {
        var result = await transaction.GetDjurAsync();
        return Ok(result.Select(djur => new DjurDtoResponse
        {
            Id = djur.Id,
            isFlying = djur.isFlying,
            SpeciesName = djur.Species,
            Weight = djur.Weight
        }).ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DjurDtoResponse>> GetDjurByIdAsync(int id)
    {
        var djur = await transaction.GetDjurByIdAsync(id);
        return Ok(new DjurDtoResponse
        {
            Id = djur.Id,
            isFlying = djur.isFlying,
            SpeciesName = djur.Species,
            Weight = djur.Weight
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDjur(int id, [FromQuery] DjurDtoRequest dto)
    {
        try
        {
            await transaction.UpdateDjur(id, dto);
            return Ok();
        }
        catch(Exception ex)
        {
           return BadRequest(ex);
        }
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateDjur([FromQuery] DjurDtoRequest djur)
    {
        await transaction.CreateDjurAsync(djur);
       return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDjur(int id)
    {
        try
        {
            await transaction.DeleteDjurAsync(id);
            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex);
        }
    }


   

}
