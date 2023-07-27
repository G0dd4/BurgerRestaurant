using BurgerRestaurant.Model;
using BurgerRestaurant.Services.CalculatorRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerRestaurant.Services
{
    public class AmountCalculatorService
    {
        private IList<ICalculatorRule> calculatorRules;
        public AmountCalculatorService() { 
            calculatorRules = new List<ICalculatorRule>()
            {
                new DrikingRule(),
                new CheeseBurgerRule(),
                new CheeseBurgerRuleMenu(),
            };

        }

        public void CalculateOrderAmount(Order order)
        {
            double total = 0;
            foreach(var item in order.Items)
            {
                var rule = calculatorRules.FirstOrDefault(r => r.IsMatch(item.Name));
                if (rule != null)
                {
                    total += rule.ApplyPrice(item);
                }
            }
            order.TotalAmount = total;
        }
    }
}
