using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using MyNightDapperProject.DTOs.ProductDTO;
using MyNightDapperProject.Repositories.ProductRepositories;

namespace MyNightDapperProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync(); //Irepository de tanimlayip repository.cs te doldurgumuz sinif
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productRepository.CreateProductAsync(createProductDTO);
            return RedirectToAction(nameof(ProductList));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var values=await _productRepository.GetByIdProductAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productRepository.UpdateProductAsync(updateProductDTO);
            return RedirectToAction(nameof(ProductList));
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return RedirectToAction(nameof(ProductList));
        }
    }
}
