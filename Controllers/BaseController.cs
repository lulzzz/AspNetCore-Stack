using AspNetCore_Stack.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Stack.Controllers
{
    public class BaseController : Controller
    {
        public User GetUser()
        {
            return HttpContext.Items["user"] as User;
        }
        
        public int GetUserId()
        {
            return GetUser().Id;
        }
    }
}