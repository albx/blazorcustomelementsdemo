using Microsoft.EntityFrameworkCore;
using MyAwesomeBlog.Core;
using MyAwesomeBlog.Core.Models;
using MyAwesomeBlog.Web.Models.Rates;

namespace MyAwesomeBlog.Web.Api.Services;

public class RatesService
{
    public MyAwesomeBlogContext Context { get; }

    public RatesService(MyAwesomeBlogContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<RateListItem>> GetRatesAsync(int postId)
    {
        var rates = await Context.Rates
            .Where(r => r.PostId == postId)
            .Select(r => new RateListItem
            {
                Id = r.Id,
                Value = r.Value
            }).ToArrayAsync();

        return rates ?? Enumerable.Empty<RateListItem>();
    }

    public async Task AddRateAsync(int postId, AddRate rate)
    {
        var post = await Context.Posts.SingleOrDefaultAsync(p => p.Id == postId);
        if (post is null)
        {
            throw new ArgumentOutOfRangeException(nameof(postId));
        }

        var newRate = new Rate
        {
            Post = post,
            Value = rate.Value
        };

        Context.Rates.Add(newRate);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteRateAsync(int postId, int rateId)
    {
        var rate = await Context.Rates
            .Where(r => r.PostId == postId)
            .SingleOrDefaultAsync(r => r.Id == rateId);

        if (rate is null)
        {
            throw new ArgumentOutOfRangeException();
        }

        Context.Rates.Remove(rate);
        await Context.SaveChangesAsync();
    }
}
