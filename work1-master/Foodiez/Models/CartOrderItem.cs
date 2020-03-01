using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class CartOrderItem
    {
        private readonly FoodiezContext _appDbContext;

        public int OrderId { get; set; }
        public string CartOrderItemId { get; set; }

        public List<OrderItem>CartOrderItemIds { get; set; }
    

        private CartOrderItem(FoodiezContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static CartOrderItem GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<FoodiezContext>();

            string orderId = session.GetString("orderId") ?? Guid.NewGuid().ToString();

            session.SetString("orderId", orderId);

            return new CartOrderItem(context) { OrderId = Convert.ToInt32(orderId) };
        }

        public void AddToCart(OrderItem order, int UnitPrice)
        {
            
            Console.WriteLine("hy i am adding to cart");
            var shoppingCartItem =
                    _appDbContext.CartOrderItemIds.SingleOrDefault(
                        s => s.order.OrderId == order.OrderItemId && s.CartOrderItemId == CartOrderItemId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new OrderItem
                {
                  CartOrderItemId = CartOrderItemId,
                    order = shoppingCartItem.order,
                    UnitPrice = 1
                };

                _appDbContext.CartOrderItemIds.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.UnitPrice++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Order order)
        {
            var shoppingCartItem =
                    _appDbContext.CartOrderItemIds.SingleOrDefault(
                        s => s.order.OrderId == order.OrderId && s.CartOrderItemId == CartOrderItemId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.UnitPrice > 1)
                {
                    shoppingCartItem.UnitPrice--;
                    localAmount = shoppingCartItem.UnitPrice;
                }
                else
                {
                    _appDbContext.CartOrderItemIds.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<OrderItem> GetShoppingCartItems()
        {
            return CartOrderItemIds ??
                   (CartOrderItemIds =
                       _appDbContext.CartOrderItemIds.Where(c => c.CartOrderItemId == CartOrderItemId)
                           .Include(s => s.order)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .CartOrderItemIds
                .Where(cart => cart.CartOrderItemId == CartOrderItemId);

            _appDbContext.CartOrderItemIds.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        //public decimal GetShoppingCartTotal()
        //{
        //    var total = _appDbContext.CartOrderItemIds.Where(c => c.CartOrderItemId == CartOrderItemId)
        //        .Select(c => c.OrderIt.UnitPrice * c.UnitPrice).Sum();
        //    return total;
        //}
    }
}
