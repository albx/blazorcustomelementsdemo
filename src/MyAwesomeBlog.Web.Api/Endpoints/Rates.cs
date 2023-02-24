namespace MyAwesomeBlog.Web.Api.Endpoints;

public static class Rates
{
    public static WebApplication MapRatesEndpoints(this WebApplication app)
    {
        var rates = app.MapGroup("/api/posts/{postId}/rates");
        rates.MapGet("/", GetRates);
        rates.MapPost("/", AddRate);
        rates.MapDelete("/{id}", DeleteRate);

        return app;
    }

    #region Handlers
    private static Task GetRates(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task AddRate(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task DeleteRate(HttpContext context)
    {
        throw new NotImplementedException();
    }
    #endregion
}
