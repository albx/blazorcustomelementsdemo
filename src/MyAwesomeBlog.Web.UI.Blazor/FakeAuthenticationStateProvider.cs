using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace MyAwesomeBlog.Web.UI.Blazor;

public class FakeAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime jsRuntime;

    public FakeAuthenticationStateProvider(IJSRuntime jsRuntime)
    {
        this.jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var userRole = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "user:role");
        var userName = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "user:name");

        string authenticationType = string.Empty;
        var claims = new List<Claim>();
        if (!string.IsNullOrWhiteSpace(userRole) && !string.IsNullOrWhiteSpace(userName))
        {
            authenticationType = "demo";
            claims.AddRange(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim(ClaimTypes.Role, userRole)
            });
        }

        var identity = new ClaimsIdentity(claims, authenticationType);
        var principal = new ClaimsPrincipal(identity);

        var state = new AuthenticationState(principal);
        return state;
    }
}
