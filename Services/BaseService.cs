using System.Linq;
using AspNetCore_Stack.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_Stack.Services
{
    public class BaseService
    {
        protected AppContext _db = new AppContext();
        
        public User GetFreshUser(int userId)
        {
            return _db
                .Users
                .Include(r => r.Role)
                .SingleOrDefault(r => r.Id == userId);
        }
    }
}