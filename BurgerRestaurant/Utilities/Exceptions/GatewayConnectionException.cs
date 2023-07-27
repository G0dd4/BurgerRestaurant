using System;

namespace BurgerRestaurant.Utilities.Exceptions
{
    public class GatewayConnectionException : OrderException
    {
        public GatewayConnectionException(string exceptionMessage) : base(exceptionMessage)
        {
        }

        public GatewayConnectionException(string exceptionMessage, OrderException innerException) : 
            base(exceptionMessage, innerException)
        {
        }
    }
}