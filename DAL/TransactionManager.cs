using DjurAPI.Data;
using DjurAPI.Models;

namespace DjurAPI.DAL;

public static class TransactionManager
{
    public static async Task<List<Djur>> GetDjurAsync()
    {
        return DB.djurs;
    }

    public static async Task<Djur?> GetDjurByIdAsync(int id)
    {
        return DB.djurs.Where(djur => djur.Id == id).FirstOrDefault();
    }
}
