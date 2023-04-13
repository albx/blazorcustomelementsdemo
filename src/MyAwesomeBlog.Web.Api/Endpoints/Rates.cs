using Microsoft.AspNetCore.Mvc;
using MyAwesomeBlog.Web.Api.Services;
using MyAwesomeBlog.Web.Models.Rates;

namespace MyAwesomeBlog.Web.Api.Endpoints;

public static class Rates
{
    public static WebApplication MapRatesEndpoints(this WebApplication app)
    {
        var rates = app.MapGroup("/api/posts/{postId}/rates").WithOpenApi();
        rates.MapGet("/", GetRates).WithName(nameof(GetRates));
        rates.MapPost("/", AddRate).WithName(nameof(AddRate));
        rates.MapDelete("/{id}", DeleteRate).WithName(nameof(DeleteRate));

        return app;
    }

    #region Handlers
    private static async Task<IResult> GetRates(int postId, RatesService service)
    {
        var rates = await service.GetRatesAsync(postId);
        return Results.Ok(rates);
    }

    private static async Task<IResult> AddRate(int postId, [FromBody] AddRate model, RatesService service)
    {
        try
        {
            await service.AddRateAsync(postId, model);
            return Results.Ok();
        }
        catch (ArgumentOutOfRangeException)
        {
            return Results.BadRequest();
        }
    }

    private static async Task<IResult> DeleteRate(int postId, int id, RatesService service)
    {
        try
        {
            await service.DeleteRateAsync(postId, id);
            return Results.NoContent();
        }
        catch (ArgumentOutOfRangeException)
        {
            return Results.NotFound();
        }
    }
    #endregion
}
