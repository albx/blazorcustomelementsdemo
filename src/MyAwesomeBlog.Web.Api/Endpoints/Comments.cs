using Microsoft.AspNetCore.Mvc;
using MyAwesomeBlog.Web.Api.Services;
using MyAwesomeBlog.Web.Models.Comments;

namespace MyAwesomeBlog.Web.Api.Endpoints;

public static class Comments
{
    public static WebApplication MapCommentsEndpoints(this WebApplication app)
    {
        var comments = app.MapGroup("/api/posts/{postId}/comments").WithOpenApi();
        comments.MapGet("/", GetComments).WithName(nameof(GetComments));
        comments.MapPost("/", AddComment).WithName(nameof(AddComment));
        comments.MapDelete("/{id}", DeleteComment).WithName(nameof(DeleteComment));

        return app;
    }

    #region Handlers
    private static async Task<IResult> GetComments(int postId, CommentsService service)
    {
        var comments = await service.GetCommentsAsync(postId);
        return Results.Ok(comments);
    }

    private static async Task<IResult> AddComment(int postId, [FromBody] AddComment model, CommentsService service)
    {
        try
        {
            await service.AddCommentAsync(postId, model);
            return Results.Ok();
        }
        catch (ArgumentOutOfRangeException)
        {
            return Results.BadRequest();
        }
    }

    private static async Task<IResult> DeleteComment(int postId, int id, CommentsService service)
    {
        try
        {
            await service.DeleteCommentAsync(postId, id);
            return Results.NoContent();
        }
        catch (ArgumentOutOfRangeException)
        {
            return Results.NotFound();
        }
    }
    #endregion
}
