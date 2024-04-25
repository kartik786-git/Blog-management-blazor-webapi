using idenitywebapiauthenitcation.Data;
using idenitywebapiauthenitcation.Entity;
using Microsoft.EntityFrameworkCore;

namespace idenitywebapiauthenitcation.Services
{
    public class BlogService : IBlogService
    {
        private readonly IdentityDbContext _identityDbContext;

        public BlogService(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }
        public async Task<List<Blog>> GetAllAsync()
        {
            var blogList = await _identityDbContext.Blogs.ToListAsync();
            return blogList;
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _identityDbContext.Blogs.Where(f => f.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _identityDbContext.AddAsync(blog);
            await _identityDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var blog = await _identityDbContext.Blogs.Where(f => f.Id == id).FirstOrDefaultAsync();
            if (blog != null)
            {
                _identityDbContext.Blogs.Remove(blog);
                await _identityDbContext.SaveChangesAsync();
                id = blog.Id;
            }
            return blog.Id > 0;
        }

       

        public async Task<bool> UpdateAsync(int id, Blog blog)
        {
            var existingBlog = await _identityDbContext.Blogs.Where(f => f.Id == id).FirstOrDefaultAsync();
            if (existingBlog != null)
            {
                existingBlog.Name = blog.Name;
                existingBlog.Description = blog.Description;
            }
            await _identityDbContext.SaveChangesAsync();
            return existingBlog.Id > 0;
        }
    }
}
