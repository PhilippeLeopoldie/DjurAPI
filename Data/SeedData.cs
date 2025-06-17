using Bogus;
using DjurAPI.Entities;
using DjurAPI.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace DjurAPI.Data;

public static class SeedData
{
    private static readonly bool[] IsFlyingArray = new[] { true, false };

    //public static List<Djur> djurs = GenerateDjur(4);

    public static async Task SeedDataAsync(this IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            var db = serviceProvider.GetRequiredService<DjurContext>();
            await db.Database.MigrateAsync();
            if (await db.Djur.AnyAsync())
            {
                return;
            }
            try
            {
                var djur = GenerateDjur(10);
                db.AddRange(djur);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
    public static List<Djur> GenerateDjur( int nbrOfDjur)
    {
        var faker = new Faker<Djur>().Rules((fake,djur)=>
        {
            djur.isFlying = fake.PickRandom(IsFlyingArray);
            djur.Species = fake.PickRandom<SpeciesType>();
            djur.Weight = fake.Random.Double(min:0.2, max:20);
        });
        return faker.Generate(nbrOfDjur);
    }
}
