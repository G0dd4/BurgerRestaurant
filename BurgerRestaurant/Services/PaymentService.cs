using BurgerRestaurant.Hardware.Api;
using BurgerRestaurant.Model;
using BurgerRestaurant.Utilities;
using BurgerRestaurant.Utilities.Exceptions;
using System;

namespace BurgerRestaurant.Services
{
    class PaymentService
    {
        CreditCardMachine CreditCardMachine;
        private double MaxAmountAvailable = 20;

        public PaymentService() {
            CreditCardMachine = new CreditCardMachine();
        }
        public void PayOrder(PaymentDetails paymentDetails, Order order)
        {
            PaymentMethodChoises(paymentDetails, order);
        }
        private void PaymentMethodChoises(PaymentDetails paymentDetails, Order order)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.ContactCreditCard)
            {
                ChargeCard(paymentDetails, order);
            }
            else if (paymentDetails.PaymentMethod == PaymentMethod.ContactLessCreditCard)
            {
                AuthorizePayment(order.TotalAmount);
                ChargeCard(paymentDetails, order);
            }
            else
            {
                throw new NotValidPaymentException();
            }
        }
        private void AuthorizePayment(double totalAmount)
        {
            if (totalAmount > MaxAmountAvailable) throw new UnAuthorizedContactLessPayment();
            Logger.Info(string.Format("Payment for {0} has been authorized", totalAmount));
        }

        private void ChargeCard(PaymentDetails paymentDetails, Order order)
        {
            try
            {
                CreditCardMachine.CardNumber = paymentDetails.CreditCardNumber;
                CreditCardMachine.ExpiresMonth = paymentDetails.ExpiresMonth;
                CreditCardMachine.ExpiresYear = paymentDetails.ExpiresYear;
                CreditCardMachine.NameOnCard = paymentDetails.CardholderName;
                CreditCardMachine.AmountToCharge = order.TotalAmount;

                CreditCardMachine.Charge();
            }
            catch(RejectedCardException ex) {
                throw new OrderException(ex);
            }


        }
    }
}
