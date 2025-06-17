using DjurAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DjurAPI.Controllers;

[ApiController]
[Route("api/Djurs")]
public class DjurController: ControllerBase
{

    [HttpGet]
    public async Task<List<Models.Djur>> GetDjursAsync()
    {
        return await DAL.TransactionManager.GetDjurAsync();
    }

    [HttpGet("{id}")]
    public async Task<Djur> GetDjurByIdAsync(int id)
    {
        return await DAL.TransactionManager.GetDjurByIdAsync(id);   
    }



   

}
