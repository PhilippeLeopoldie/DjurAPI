using DjurAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DjurAPI.Data;

public class DjurContext:DbContext
{
    public DjurContext(DbContextOptions<DjurContext> options) 
        : base(options)
    { 

    }

    public DbSet<Djur> Djur { get; set; } = default!;
}
