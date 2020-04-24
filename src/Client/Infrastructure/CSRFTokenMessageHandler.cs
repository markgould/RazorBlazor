using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1.Client.Infrastructure
{
    public class CSRFTokenMessageHandler : DelegatingHandler
    {
        private readonly IBrowserCookieService _browserCookieService;

        public CSRFTokenMessageHandler(IBrowserCookieService browserCookieService)
        {
            _browserCookieService = browserCookieService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method != HttpMethod.Get)
            {
                var cookie = await _browserCookieService.Get("CSRF-TOKEN");

                if (!string.IsNullOrEmpty(cookie))
                    request.Content.Headers.TryAddWithoutValidation("X-CSRF-TOKEN", cookie);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
