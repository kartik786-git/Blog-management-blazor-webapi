using idenitywebapiauthenitcation.Entity;

namespace idenitywebapiauthenitcation.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> CreateAsync(Blog blog);
        Task<bool> UpdateAsync(int id, Blog blog);
        Task<bool> DeleteAsync(int id);
    }
}
