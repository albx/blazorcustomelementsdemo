using Microsoft.EntityFrameworkCore;
using MyAwesomeBlog.Core;
using MyAwesomeBlog.Core.Models;
using MyAwesomeBlog.Web.Models.Posts;

namespace MyAwesomeBlog.Web.Api.Services;

public class PostsService
{
    public MyAwesomeBlogContext Context { get; }

    public PostsService(MyAwesomeBlogContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<PostListItem>> GetPostsAsync()
    {
        var posts = await Context.Posts
            .OrderBy(p => p.PublishDate)
            .Select(p => new PostListItem
            {
                Id = p.Id,
                PublishDate = p.PublishDate,
                Slug = p.Slug,
                Title = p.Title
            }).ToArrayAsync();

        return posts ?? Enumerable.Empty<PostListItem>();
    }

    public async Task<PostDetail?> GetPostDetailAsync(int postId)
    {
        var post = await Context.Posts.SingleOrDefaultAsync(p => p.Id == postId);
        if (post is null)
        {
            return null;
        }

        return new PostDetail
        {
            Id = post.Id,
            Content = post.Content,
            PublishDate = post.PublishDate,
            Slug = post.Slug,
            Title = post.Title
        };
    }

    public async Task<PostDetail> CreateNewPostAsync(NewPost post)
    {
        var newPost = new Post
        {
            Title = post.Title,
            Slug = post.Slug,
            Content = post.Content,
            PublishDate = DateTime.Now
        };

        Context.Add(newPost);
        await Context.SaveChangesAsync();

        return new PostDetail
        {
            Id = newPost.Id,
            Content = newPost.Content,
            PublishDate = newPost.PublishDate,
            Slug = newPost.Slug,
            Title = newPost.Title
        };
    }

    public async Task EditPostAsync(int postId, PostDetail post)
    {
        var postToEdit = await Context.Posts.SingleOrDefaultAsync(p => p.Id == postId);
        if (postToEdit is null)
        {
            throw new ArgumentOutOfRangeException(nameof(postId));
        }

        postToEdit.Title = post.Title;
        postToEdit.Content = post.Content;

        await Context.SaveChangesAsync();
    }

    public async Task DeletePostAsync(int postId)
    {
        var post = await Context.Posts.SingleOrDefaultAsync(p => p.Id == postId);
        if (post is null)
        {
            throw new ArgumentOutOfRangeException(nameof(postId));
        }

        Context.Posts.Remove(post);
        await Context.SaveChangesAsync();
    }
}
