namespace BurgerRestaurant.Utilities.Exceptions
{
    public class NotValidPaymentException : OrderException
    {
        public NotValidPaymentException()
            :base("Can not charge customer")
        {
        }
    }
}