namespace MyAwesomeBlog.Web.Api.Endpoints;

public static class Posts
{
    public static WebApplication MapPostsEndpoints(this WebApplication app)
    {
        var posts = app.MapGroup("/api/posts");
        posts.MapGet("/", GetPosts);
        posts.MapGet("/{id}", GetPostDetail);
        posts.MapPost("/", CreateNewPost);
        posts.MapPut("/{id}", EditPost);
        posts.MapDelete("/{id}", DeletePost);

        return app;
    }

    #region Handlers
    private static Task GetPosts(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task GetPostDetail(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task CreateNewPost(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task EditPost(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task DeletePost(HttpContext context)
    {
        throw new NotImplementedException();
    }
    #endregion
}
