using DjurAPI.Data;
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
}
