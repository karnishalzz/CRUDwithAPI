using Microsoft.EntityFrameworkCore;
using ProjectAPI.ApiModels.CategoryModels;
using ProjectAPI.Data;
using ProjectAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDetails>> GetCategoryListAsync()
        {
            List<CategoryDetails> departmentList = await _context.Category
                .Select(c => new CategoryDetails
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                   
                }).ToListAsync();

            return departmentList;
        }

        public async Task CreateCategoryAsync(CreateCategory createCategory)
        {
            if (createCategory == null)
            {
                throw new ArgumentNullException(nameof(createCategory));
            }

            Category categoryToBeCreated = new Category()
            {
                CategoryName = createCategory.CategoryName,
                Description = createCategory.Description
            };

            await _context.AddAsync(categoryToBeCreated);
            await _context.SaveChangesAsync();
        }

        

        public async Task<CategoryDetails> GetCategoryAsync(int categoryId)
        {
            CategoryDetails categoryDetail = await _context.Category.Where(c => c.CategoryId == categoryId)
                .Select(c => new CategoryDetails
                {
                     CategoryId= c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                   
                }).FirstOrDefaultAsync();

            return categoryDetail;
        }

        public async Task UpdateCategoryAsync(UpdateCategory updateCategory)
        {
            if (updateCategory == null)
            {
                throw new ArgumentNullException(nameof(updateCategory));
            }

            Category categoryToBeUpdated = await _context.Category.FindAsync(updateCategory.CategoryId);
            if (categoryToBeUpdated != null)
            {
                categoryToBeUpdated.CategoryName = updateCategory.CategoryName;
                categoryToBeUpdated.Description = updateCategory.Description;
                
                _context.Category.Update(categoryToBeUpdated);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategory(int categoryId)
        {
            Category categoryToBeDeleted = await _context.Category.FindAsync(categoryId);
            if (categoryToBeDeleted != null)
            {
                _context.Category.Remove(categoryToBeDeleted);
                await _context.SaveChangesAsync();
            }
        }
    }
}
