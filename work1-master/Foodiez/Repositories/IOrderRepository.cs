using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

    }
}
