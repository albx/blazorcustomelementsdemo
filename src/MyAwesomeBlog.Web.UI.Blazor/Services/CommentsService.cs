using MyAwesomeBlog.Web.Models.Comments;
using System.Net.Http.Json;

namespace MyAwesomeBlog.Web.UI.Blazor.Services;

public class CommentsService
{
    public HttpClient Client { get; }

    public CommentsService(HttpClient client)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<IEnumerable<CommentListItem>> LoadCommentsForPost(int postId)
    {
        var items = await Client.GetFromJsonAsync<IEnumerable<CommentListItem>>($"api/posts/{postId}/comments");
        return items ?? Enumerable.Empty<CommentListItem>();
    }

    public async Task AddCommentAsync(int postId, AddComment comment)
    {
        var response = await Client.PostAsJsonAsync($"api/posts/{postId}/comments", comment);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteCommentAsync(int postId, int commentId)
    {
        var response = await Client.DeleteAsync($"api/posts/{postId}/comments/{commentId}");
        response.EnsureSuccessStatusCode();
    }
}
