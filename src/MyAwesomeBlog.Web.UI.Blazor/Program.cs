using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyAwesomeBlog.Web.UI.Blazor;
using MyAwesomeBlog.Web.UI.Blazor.Components;
using MyAwesomeBlog.Web.UI.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.RootComponents.RegisterCustomElement<PostComments>("post-comments");

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, FakeAuthenticationStateProvider>();
builder.Services.AddHttpClient<CommentsService>(client => client.BaseAddress = new Uri("http://localhost:5238"));

await builder.Build().RunAsync();
