namespace MyAwesomeBlog.Web.Api.Endpoints;

public static class Comments
{
    public static WebApplication MapCommentsEndpoints(this WebApplication app)
    {
        var comments = app.MapGroup("/api/posts/{postId}/comments");
        comments.MapGet("/", GetComments);
        comments.MapGet("/{id}", GetCommentDetail);
        comments.MapPost("/", AddComment);
        comments.MapDelete("/{id}", DeleteComment);

        return app;
    }

    #region Handlers
    private static Task GetComments(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task GetCommentDetail(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task AddComment(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static Task DeleteComment(HttpContext context)
    {
        throw new NotImplementedException();
    }
    #endregion
}
