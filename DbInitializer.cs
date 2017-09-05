using AspNetCore_Stack.Entities;

namespace AspNetCore_Stack
{
    public class DbInitializer
    {
        public static void Init(AppContext _db)
        {
            _db.Database.EnsureCreated();
        }
    }
}