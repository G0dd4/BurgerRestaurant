using BurgerRestaurant.Model;
using BurgerRestaurant.Services;

namespace BurgerRestaurant
{
    public class McBurgerRestaurant
    {
        readonly AmountCalculatorService calculatorService;
        readonly PaymentService paymentService;
        readonly PrinterService printerService;
        readonly KitchenService kitchenService;
        public McBurgerRestaurant()
        {
            calculatorService = new AmountCalculatorService();
            paymentService = new PaymentService();
            printerService = new PrinterService();
            kitchenService = new KitchenService();
        }
        public void ExecuteOrder(Order order, PaymentDetails paymentDetails, bool printReceipt)
        {
            calculatorService.CalculateOrderAmount(order);

            paymentService.PayOrder(paymentDetails, order);

            kitchenService.PrepareOrder(order.Items);

            if (printReceipt)
            {
                printerService.PrintReceipt(order);
            }
        }
    }
}
