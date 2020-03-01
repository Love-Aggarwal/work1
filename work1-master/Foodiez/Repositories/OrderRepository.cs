using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodiezContext _appDbContext;
        private readonly CartOrderItem _shoppingCart;


        public OrderRepository(FoodiezContext appDbContext, CartOrderItem shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;

            _appDbContext.Order.Add(order);

            var shoppingCartItems = _shoppingCart.CartOrderItemIds;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderItem()
                {
                    UnitPrice = shoppingCartItem.UnitPrice,
                    FoodId = shoppingCartItem.FoodId,
                    order = shoppingCartItem.order

                };

                _appDbContext.CartOrderItemIds.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }


    }
}
