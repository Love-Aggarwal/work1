using System.ComponentModel.DataAnnotations;
namespace Foodiez.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; private set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public string CartOrderItemId { get; set; }
        public Order order { get; set; }
        //public FoodItem FoodItem { get; set; }
    }
}
