using System.Collections.Generic;
using BurgerRestaurant.Model;

namespace BurgerRestaurant.Hardware.Api
{
    public class HpPrinter : IMachine
    {
        public void Print(Receipt receipt)
        {
            //Doing some printing            
        }

        public void Fax(Receipt item)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Receipt item)
        {
            throw new System.NotImplementedException();
        }
    }
}