using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    public enum Items
    {
        Apple = 1,
        Cheerios = 2,
        Milk = 3,
        Robster = 4
    }

    public static class ItemPriceCalculator {
        // in practice, we store item prices in Database or in an xml file, but I'm simplifying the application by 
        // removing external dependencies and hardcoding item prices here
        const double APPLE_PRICE = 12;
        const double CHEERIOS_PRICE = 130;
        const double MILK_PRICE = 3.5;
        const double ROBSTER_PRICE = 80;

        public static double GetPrice(this Items item)
        {
            double price = 0;
            switch (item)
            {
                case Items.Apple:
                    price = APPLE_PRICE;
                    break;
                case Items.Cheerios:
                    price = CHEERIOS_PRICE;
                    break;
                case Items.Milk:
                    price = MILK_PRICE;
                    break;
                case Items.Robster:
                    price = ROBSTER_PRICE;
                    break;
            }

            return price;
        }
    }
}
