using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class PostRepository
    {
        internal static async Task<List<Post>> GetPostsAsync()
        {
            using ( var context = new AppDbContext()) 
            {
                return await context.Posts.ToListAsync();
            }
        }

        internal async static Task<Post> GetPostByIdAsync(int postId)
        {
            using (var context = new AppDbContext())
            {
                return await context.Posts.FirstOrDefaultAsync(post => post.PostId == postId);
            }
        }

        internal async static Task<bool> CreatePostAsync(Post postToCreate)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    await context.Posts.AddAsync(postToCreate);
                    return await context.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdatePostAsync(Post postToCreate)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Posts.Update(postToCreate);
                    return await context.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeletePostAsync(int postId)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    Post postToDelete = await GetPostByIdAsync(postId);
                    context.Posts.Remove(postToDelete);

                    return await context.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
