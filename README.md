# RazorBlazor

POC showing how Blazor WASM can be embedded inside an MVC/Razor Pages site

Handles CSRF on post back, thanks to https://github.com/RemiBou/Toss.Blazor for the inspiration

Routing is handled by using Razor page handlers - a handler that doesn't exist will resolve to the default handler (OnGet), and then Blazor is able to use that to show the correct page.
