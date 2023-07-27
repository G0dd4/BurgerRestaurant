using System.Collections.Generic;
using BurgerRestaurant.Model;
using BurgerRestaurant.Model.MenuItems;

namespace BurgerRestaurant.Services
{
    public class CookingService
    {
        private readonly Dictionary<ItemsName, MenuItem> restaurantMenu = new Dictionary<ItemsName, MenuItem>
        {
            { ItemsName.Drink, new Drink()},
            { ItemsName.CheeseBurger, new CheeseBurger()},
            { ItemsName.CheeseBurgerMenu, new CheeseBurgerMenu()}
        };

        public void Prepare(ItemsName itemName, int quantity)
        {
            var menuItem = restaurantMenu[itemName];
            if (menuItem is CheeseBurgerMenu || menuItem is CheeseBurger)
            {
                for (int i = 0; i < quantity; i++)
                {
                    menuItem.GetPrerequisites();
                    menuItem.Prepare();
                    menuItem.SendToService();
                }
            }
            else if (menuItem is Drink)
            {
                menuItem.SendToService();
            }
        }
    }
}