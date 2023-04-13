using Microsoft.EntityFrameworkCore;
using MyAwesomeBlog.Core;
using MyAwesomeBlog.Core.Models;
using MyAwesomeBlog.Web.Models.Comments;

namespace MyAwesomeBlog.Web.Api.Services;

public class CommentsService
{
    public MyAwesomeBlogContext Context { get; }

    public CommentsService(MyAwesomeBlogContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<CommentListItem>> GetCommentsAsync(int postId)
    {
        var comments = await Context.Comments
            .Where(c => c.PostId == postId)
            .OrderByDescending(c => c.PostedAt)
            .Select(c => new CommentListItem
            {
                Id = c.Id,
                Author = c.Author,
                Content = c.Content,
                PostedAt = c.PostedAt
            }).ToArrayAsync();

        return comments ?? Enumerable.Empty<CommentListItem>();
    }

    public async Task AddCommentAsync(int postId, AddComment comment)
    {
        var post = await Context.Posts.SingleOrDefaultAsync(p => p.Id == postId);
        if (post is null)
        {
            throw new ArgumentOutOfRangeException(nameof(postId));
        }

        var newComment = new Comment
        {
            Post = post,
            Author = comment.Author,
            Content = comment.Content,
            PostedAt = DateTime.Now
        };

        Context.Add(newComment);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(int postId, int commentId)
    {
        var comment = await Context.Comments
            .Where(c => c.PostId == postId)
            .SingleOrDefaultAsync(c => c.Id == commentId);

        if (comment is null)
        {
            throw new ArgumentOutOfRangeException();
        }

        Context.Remove(comment);
        await Context.SaveChangesAsync();
    }
}
