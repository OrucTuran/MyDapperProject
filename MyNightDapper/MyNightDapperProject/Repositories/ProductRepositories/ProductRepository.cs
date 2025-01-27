using Dapper;
using MyNightDapperProject.Context;
using MyNightDapperProject.DTOs.ProductDTO;

namespace MyNightDapperProject.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _dapperContext;
        public ProductRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateProductAsync(CreateProductDTO createProductDTO)
        {
            string query = "insert into Products (ProductName,ProductStock,ProductPrice) values(@productName, @productStock, @productPrice)";

            var parameters = new DynamicParameters();

            parameters.Add("@productName", createProductDTO.ProductName);
            parameters.Add("@productStock", createProductDTO.ProductStock);
            parameters.Add("@productPrice", createProductDTO.ProductPrice);

            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteProductAsync(int id)
        {
            string query = "Delete From Products Where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultProductDTO>> GetAllProductAsync()
        {
            string query = "Select * From Products";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultProductDTO>(query);
            return values.ToList();
        }

        public async Task<GetByIdProductDTO> GetByIdProductAsync(int id)
        {
            string query = "Select * From Products Where ProductID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdProductDTO>(query, parameters);
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            string query = "Update Products SET ProductName = @productName, ProductStock=@productStock, ProductPrice=@productPrice Where ProductID=@productId";

            var parameters = new DynamicParameters();

            parameters.Add("@productName", updateProductDTO.ProductName);
            parameters.Add("@productId", updateProductDTO.ProductID);
            parameters.Add("@productStock", updateProductDTO.ProductStock);
            parameters.Add("@productPrice", updateProductDTO.ProductPrice);

            var connection = _dapperContext.CreateConnection();

            await connection.ExecuteAsync(query, parameters);
        }
    }
}
