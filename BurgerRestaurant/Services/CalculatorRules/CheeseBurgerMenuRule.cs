using BurgerRestaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BurgerRestaurant.Services.CalculatorRules
{
    public class CheeseBurgerRuleMenu : ICalculatorRule
    {
        public double ApplyPrice(OrderItem item)
        {
            return item.Price * item.Quantity*0.9;
        }

        public bool IsMatch(ItemsName item)
        {
            return item == ItemsName.CheeseBurgerMenu;
        }
    }
}
