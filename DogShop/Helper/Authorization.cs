using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DogShop.Models;

namespace DogShop.Helper
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Roles> _roles;

        public Authorization(params Roles[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject =
                new JsonResult(new { Message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

            if (_roles == null)
            {
                context.Result = unauthorizedStatusObject;
            }

            User? user = context.HttpContext.Items["User"] as User;

            if (user == null || !_roles.Contains(user.Role))
            {
                Console.WriteLine("asdfASaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
