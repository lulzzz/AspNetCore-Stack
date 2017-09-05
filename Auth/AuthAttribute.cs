using AspNetCore_Stack.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCore_Stack.Auth
{
    public class AuthAttribute : ActionFilterAttribute
    {
        private readonly string _routeRole;

        public AuthAttribute()
        {
        }

        public AuthAttribute(string routeRole)
        {
            _routeRole = routeRole;
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (_routeRole == null)
            {
                base.OnActionExecuting(context);
                return;
            }
            
            var user = context.HttpContext.Items["user"] as User;

            if (user == null)
            {
                context.Result = new BadRequestObjectResult("Unauthorized request");
                base.OnActionExecuting(context);
                return;
            }
            
            var authorized = false;

            var userRole = user.Role?.RoleName;

            if (userRole != null && userRole == _routeRole)
            {
                authorized = true;
            }
            
            if (authorized == false)
            {
                context.Result = new BadRequestObjectResult("Unauthorized request");
                base.OnActionExecuting(context);
            } 
            
            // go on...
        }

    }
}