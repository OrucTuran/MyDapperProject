using MyNightDapperProject.DTOs.CategoryDTO;

namespace MyNightDapperProject.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO);
        Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO);
        Task DeleteCategoryAsync(int id);
        Task<GetByIdCategoryDTO> GetByIdCategoryAsync(int id);
    }
}
