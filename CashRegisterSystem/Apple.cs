using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    public class Apple : AbstractItem
    {
        private double pricePerPound; // encapsulate what varies and avoid injecting dependency
        private double weightInPound;

        public Apple(double weightInPound)
        {
            if (weightInPound <= 0)
            {
                throw new ArgumentException("Weight of apple can't be zero or negative.");
            }

            this.weightInPound = weightInPound;
            this.name = "Apple";
            this.item = Items.Apple;
            this.pricePerPound = ItemPriceCalculator.GetPrice(Items.Apple);
        }

        public override double GetPrice()
        {
            this.price = this.weightInPound * this.pricePerPound;
            return this.price;
        }

        public void SetPricePerPound(double newPricePerPound)
        {
            this.pricePerPound = newPricePerPound;
        }
    }
}
