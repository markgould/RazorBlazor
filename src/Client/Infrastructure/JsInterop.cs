using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace WebApplication1.Client.Infrastructure
{
    public interface IJsInterop
    {
        Task<string> GetCookie();

        ValueTask ShowAlert(string alert);
    }

    public class JsInterop : IJsInterop
    {
        private readonly IJSRuntime _jsRuntime;

        public JsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<string> GetCookie()
        {
            return await _jsRuntime.InvokeAsync<string>("getDocumentCookie");
        }

        public ValueTask ShowAlert(string alert)
        {
            return _jsRuntime.InvokeVoidAsync("showAlert", alert);
        }
    }
}
