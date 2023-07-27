using BurgerRestaurant.Hardware.Api;
using BurgerRestaurant.Model;
using BurgerRestaurant.Utilities;
using System;
using System.Collections.Generic;

namespace BurgerRestaurant.Services
{
    public class PrinterService
    {
        readonly HpPrinter printer;
        public PrinterService() 
        { 
            printer = new HpPrinter();
        }
        public void PrintReceipt(Order order)
        {
            if (order.CustomerEmail is null)
            {
                var receipt = new Receipt
                {
                    Title = $"Receipt for your order placed on {DateTime.Now}",
                    Body = "Your order details : \n"
                };

                receipt.Body = PrintOrderItem(order.Items);
            }
        }
        private string PrintOrderItem(IEnumerable<OrderItem> orders)
        {
            string orderItem = "";
            foreach(var item in orders)
            {
                orderItem += $"{item.Quantity} of {Enum.GetName(typeof(ItemsName), item.Name)}\n";
            }
            return orderItem;
        } 
        private void Print(Receipt receipt)
        {
            try
            {
                printer.Print(receipt);
            }
            catch (Exception ex)
            {
                Logger.Error("Problem sending notification email", ex);
            }
        }

    }
}
