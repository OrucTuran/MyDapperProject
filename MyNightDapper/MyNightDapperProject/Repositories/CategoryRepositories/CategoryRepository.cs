using Dapper;
using MyNightDapperProject.Context;
using MyNightDapperProject.DTOs.CategoryDTO;

namespace MyNightDapperProject.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;

        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            string query = "insert into Categories (CategoryName) values (@categoryName)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryName", createCategoryDTO.CategoryName);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            string query = "Delete From Categories Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
        {
            string query = "Select*From Categories";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultCategoryDTO>(query);
            return values.ToList();
        }

        public async Task<GetByIdCategoryDTO> GetByIdCategoryAsync(int id)
        {
            string query = "Select * From Categories Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", id);
            var connection = _context.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDTO>(query);
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            string query = "Update Categories SET CategoryName=@categoryName Where CategoryId=@categoryId";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryId", updateCategoryDTO.CategoryID);
            parameters.Add("@categoryName", updateCategoryDTO.CategoryName);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
