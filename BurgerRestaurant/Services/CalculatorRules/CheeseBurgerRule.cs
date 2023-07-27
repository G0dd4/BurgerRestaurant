using BurgerRestaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BurgerRestaurant.Services.CalculatorRules
{
    public class CheeseBurgerRule : ICalculatorRule
    {
        public double ApplyPrice(OrderItem item)
        {
            return item.Price * item.Quantity;
        }

        public bool IsMatch(ItemsName item)
        {
            return item == ItemsName.CheeseBurger;
        }
    }
}
