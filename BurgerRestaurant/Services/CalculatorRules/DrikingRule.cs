using BurgerRestaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerRestaurant.Services.CalculatorRules
{
    internal class DrikingRule : ICalculatorRule
    {
        public double ApplyPrice(OrderItem item)
        {
            var setsOfThree = item.Quantity / 3;
            return (item.Quantity - setsOfThree) * item.Price;
        }

        public bool IsMatch(ItemsName item)
        {
            return item == ItemsName.Drink;
        }
    }
}
