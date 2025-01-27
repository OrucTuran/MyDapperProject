using MyNightDapperProject.DTOs.CategoryDTO;
using MyNightDapperProject.DTOs.ProductDTO;

namespace MyNightDapperProject.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDTO createProductDTO);
        Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task DeleteProductAsync(int id);
        Task<GetByIdProductDTO> GetByIdProductAsync(int id);
    }
}
