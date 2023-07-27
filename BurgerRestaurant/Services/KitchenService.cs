using BurgerRestaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerRestaurant.Services
{
    public class KitchenService
    {
        public KitchenService()
        { 
        
        }

        public void PrepareOrder(IEnumerable<OrderItem> orderItem)
        {
            var cooker = new CookingService();
            foreach (var item in orderItem)
            {
                cooker.Prepare(item.Name, item.Quantity);
            }
        }
    }
}
