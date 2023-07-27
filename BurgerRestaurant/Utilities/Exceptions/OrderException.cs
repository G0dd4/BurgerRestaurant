using System;

namespace BurgerRestaurant.Utilities.Exceptions
{
    public class OrderException : Exception
    {

        
        public OrderException(string message) :
        base(message)
        {
        }

        public OrderException(string message, OrderException ex) :
        base(message, ex)
        {
        }


        public OrderException(GatewayConnectionException ex) :
            base("Can not connect to gateway",ex)
        { 
        }

        public OrderException(OrderException innerException) :
            base("The card getway rejected the card.")
        {
        }
    }
}