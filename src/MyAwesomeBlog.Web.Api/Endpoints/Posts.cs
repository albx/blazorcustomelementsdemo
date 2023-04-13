using Microsoft.AspNetCore.Mvc;
using MyAwesomeBlog.Web.Api.Services;
using MyAwesomeBlog.Web.Models.Posts;

namespace MyAwesomeBlog.Web.Api.Endpoints;

public static class Posts
{
    public static WebApplication MapPostsEndpoints(this WebApplication app)
    {
        var posts = app.MapGroup("/api/posts").WithOpenApi();
        posts.MapGet("/", GetPosts).WithName(nameof(GetPosts));
        posts.MapGet("/{id}", GetPostDetail).WithName(nameof(GetPostDetail));
        posts.MapPost("/", CreateNewPost).WithName(nameof(CreateNewPost));
        posts.MapPut("/{id}", EditPost).WithName(nameof(EditPost));
        posts.MapDelete("/{id}", DeletePost).WithName(nameof(DeletePost));

        return app;
    }

    #region Handlers
    private static async Task<IResult> GetPosts(PostsService service)
    {
        var posts = await service.GetPostsAsync();
        return Results.Ok(posts);
    }

    private static async Task<IResult> GetPostDetail(int id, PostsService service)
    {
        var post = await service.GetPostDetailAsync(id);
        if (post is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(post);
    }

    private static async Task<IResult> CreateNewPost([FromBody] NewPost model, PostsService service)
    {
        var createdPost = await service.CreateNewPostAsync(model);
        return Results.CreatedAtRoute(nameof(GetPostDetail), new { id = createdPost.Id }, createdPost);
    }

    private static async Task<IResult> EditPost(int id, [FromBody] PostDetail model, PostsService service)
    {
        try
        {
            await service.EditPostAsync(id, model);
            return Results.NoContent();
        }
        catch (ArgumentOutOfRangeException)
        {
            return Results.NotFound();
        }
    }

    private static async Task<IResult> DeletePost(int id, PostsService service)
    {
        try
        {
            await service.DeletePostAsync(id);
            return Results.NoContent();
        }
        catch (ArgumentOutOfRangeException)
        {
            return Results.NotFound();
        }
    }
    #endregion
}
