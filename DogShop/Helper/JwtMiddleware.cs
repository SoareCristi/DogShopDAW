using DogShop.Services;

namespace DogShop.Helper
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpcontext, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = httpcontext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {
                httpcontext.Items["User"] = userService.GetById(userId);
            }

            await _nextRequestDelegate(httpcontext);
        }
    }
}
