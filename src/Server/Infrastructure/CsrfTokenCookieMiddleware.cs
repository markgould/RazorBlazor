using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Server.Infrastructure
{
    public class CsrfTokenCookieMiddleware
    {
        private readonly IAntiforgery _antiforgery;
        private readonly RequestDelegate _next;

        public CsrfTokenCookieMiddleware(IAntiforgery antiforgery, RequestDelegate next)
        {
            _antiforgery = antiforgery;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies["CSRF-TOKEN"] == null)
            {
                var token = _antiforgery.GetAndStoreTokens(context);
                context.Response.Cookies.Append("CSRF-TOKEN", token.RequestToken, new CookieOptions { HttpOnly = false });
            }
            await _next(context);
        }
    }
}
