using BlazorAppSecure.Model;

namespace BlazorAppSecure.Sevices
{
    public interface IBlogService
    {
        Task<List<BlogViewModel>> GetAllAsync();
        Task<BlogViewModel> GetByIdAsync(int id);
        Task<BlogViewModel> CreateAsync(BlogViewModel blog);
        Task<bool> UpdateAsync(int id, BlogViewModel blog);
        Task<bool> DeleteAsync(int id);
    }
}
