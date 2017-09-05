using System.Linq;
using System.Threading.Tasks;
using AspNetCore_Stack.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using AppContext = AspNetCore_Stack.Entities.AppContext;

namespace AspNetCore_Stack.Auth
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
            StringValues token;
            context.Request.Headers.TryGetValue(HeaderNames.Authorization, out token);

            if (token.Count == 0)
            {
                await _next(context);
                return;
            }
              
            var user = GetUserFromToken(token);
            
            if (user == null)
            {
                await _next(context);
                return;
            }
            
            context.Items["user"] = user;

            await _next(context);
        }
        
        private static User GetUserFromToken(string token)
        {
            using (var db = new AppContext())
            {

                var tokenModel = db
                    .UserTokens
                    .Where(r => r.TokenValue == token);

                if (tokenModel.FirstOrDefault() == null)
                {
                    return null;
                }
                
                return tokenModel
                    .Include(r => r.User)
                    .Include(r => r.User.Role)
                    .FirstOrDefault()
                    .User;
            }
        }
    }
}