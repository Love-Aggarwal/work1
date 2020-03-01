using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
