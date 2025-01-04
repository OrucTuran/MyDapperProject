using Microsoft.AspNetCore.Mvc;
using MyNightDapperProject.DTOs.CategoryDTO;
using MyNightDapperProject.Repositories.CategoryRepositories;

namespace MyNightDapperProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return View(values); // CategoryList.cshtml sayfasına veri gönderilir
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(); // CreateCategory.cshtml sayfasını döndürür
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.CreateCategoryAsync(createCategoryDTO);
                return RedirectToAction(nameof(CategoryList)); // Kategori ekledikten sonra listeye geri dön
            }
            return View(createCategoryDTO); // Model geçersizse aynı sayfaya geri döner
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(CategoryList)); // Kategori silindikten sonra listeye geri dön
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var values = await _categoryRepository.GetByIdCategoryAsync(id);
            if (values == null)
            {
                return NotFound(); // Kategori bulunamazsa 404 hatası döndür
            }
            return View(values); // Güncelleme sayfasını döndür
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateCategoryAsync(updateCategoryDTO);
                return RedirectToAction(nameof(CategoryList)); // Kategori güncellendikten sonra listeye dön
            }
            return View(updateCategoryDTO); // Model geçersizse aynı sayfaya geri döner
        }
    }
}
