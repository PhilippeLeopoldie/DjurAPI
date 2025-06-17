using Bogus;
using DjurAPI.Models;

namespace DjurAPI.DAL;

public class DB
{
    private static readonly bool[] IsFlyingArray = new[] { true, false };

    public static List<Djur> djurs = djurGenerator(4);
    

    public static List<Djur> djurGenerator(int nbrOfDjur)
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
