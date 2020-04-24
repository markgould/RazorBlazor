using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Client.Infrastructure
{
    public interface IBrowserCookieService
    {
        Task<string> Get(string cookieName);
    }

    /// <summary>
    /// Service for reading the current cookie on the browser
    /// </summary>
    public class BrowserCookieService : IBrowserCookieService
    {
        private readonly IJsInterop _jsInterop;

        public BrowserCookieService(IJsInterop jsInterop)
        {
            _jsInterop = jsInterop;
        }

        /// <summary>
        /// returns the cookie value or null if not set
        /// </summary>
        /// <param name="cookieName">Name of the cookie</param>
        /// <returns>The cookie data</returns>
        public async Task<string> Get(string cookieName)
        {
            var cookie= (await _jsInterop.GetCookie())
                .Split(';')
                .Select(v => v.TrimStart().Split('='))
                .FirstOrDefault(s => s[0] == cookieName);

            return cookie?[1];
        }
    }
}
