using Microsoft.EntityFrameworkCore;

namespace DjurAPI.Data;

public class DjurContext:DbContext
{
    public DjurContext(DbContextOptions<DjurContext> options) 
        : base(options)
    { 

    }

    public DbSet<DjurAPI.Models.Djur> Djur { get; set; } = default!;
}
