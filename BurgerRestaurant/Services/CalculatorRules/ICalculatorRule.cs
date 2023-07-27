using BurgerRestaurant.Model;

namespace BurgerRestaurant.Services.CalculatorRules
{
    public interface ICalculatorRule
    {
        bool IsMatch(ItemsName item);
        double ApplyPrice(OrderItem item);

    }
}
