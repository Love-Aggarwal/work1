using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public interface IFoodItemRepository
    {
        IEnumerable<FoodItem> AllFood { get; }
        FoodItem GetFoodById(int FoodId);
        FoodItem Add(FoodItem fooditem);
        FoodItem Update(FoodItem fooditems);
        FoodItem Delete(int Id);


    }
}
