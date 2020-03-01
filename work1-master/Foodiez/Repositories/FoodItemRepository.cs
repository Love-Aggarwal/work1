using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly FoodiezContext _appDbContext;

        public FoodItemRepository(FoodiezContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<FoodItem> AllFood
        {
            get
            {
                return _appDbContext.FoodItem.Include(c => c.Category);
            }
        }

        public FoodItem Add(FoodItem fooditem)
        {
            _appDbContext.FoodItem.Add(fooditem);
            _appDbContext.SaveChanges();
            return fooditem;
        }

        public FoodItem Delete(int Id)
        {
            FoodItem fooditem = _appDbContext.FoodItem.Find(Id);
            if (fooditem != null)
            {
                _appDbContext.FoodItem.Remove(fooditem);
                _appDbContext.SaveChanges();
            }
            return fooditem;
        }

        public FoodItem GetFoodById(int foodId)
        {
            return _appDbContext.FoodItem.FirstOrDefault(p => p.Id == foodId);
        }

        public FoodItem Update(FoodItem fooditems)
        {
            var fooditem = _appDbContext.FoodItem.Attach(fooditems);
            fooditem.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
            return fooditems;
        }
    }
}
