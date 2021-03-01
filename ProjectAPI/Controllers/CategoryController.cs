using Microsoft.AspNetCore.Mvc;
using ProjectAPI.ApiModels.CategoryModels;
using ProjectAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class CategoryController : ControllerBase
        {
            private readonly CategoryService _categoryService;
            

            public CategoryController(CategoryService categoryService)
            {
                _categoryService = categoryService;
        
            }

            [HttpGet]
            public async Task<List<CategoryDetails>> GetCategoryList()
            {
                List<CategoryDetails> categoryDetails = await _categoryService.GetCategoryListAsync();

                return categoryDetails;
            }

            [HttpPost]
            public async Task<IActionResult> CreateCategory([FromBody] CreateCategory createCategory)
            {
                await _categoryService.CreateCategoryAsync(createCategory);
                return Ok();
            }

          

            [HttpGet("{categoryId}")]
            public async Task<CategoryDetails> GetDepartment(int categoryId)
            {
                CategoryDetails categoryDetail = await _categoryService.GetCategoryAsync(categoryId);
                return categoryDetail;
            }

            [HttpPut]
            public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategory updateCategory)
            {

                await _categoryService.UpdateCategoryAsync(updateCategory);
                return Ok();
            }

            [HttpDelete("{categoryId}")]
            public async Task<IActionResult> DeleteCategory(int categoryId)
            {
                await _categoryService.DeleteCategory(categoryId);
                return Ok();
            }
        }
}
