using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly FoodiezContext _appDbContext;

        public CategoryRepository(FoodiezContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;

    }
}
