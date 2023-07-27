namespace BurgerRestaurant.Utilities.Exceptions
{
    public class UnAuthorizedContactLessPayment : OrderException
    {
        public UnAuthorizedContactLessPayment()
            : base ("Amount is too big")
        {
        }
    }
}