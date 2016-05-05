using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    public class Cheerios : AbstractItem
    {
        public Cheerios()
        {
            this.name = "Cheerios";
            this.item = Items.Cheerios;
            this.price = ItemPriceCalculator.GetPrice(Items.Cheerios); // encapsulate what varies and avoid injecting dependency
        }

        public sealed override double GetPrice()
        {
            return this.price;
        }

        public void SetPrice(double newPrice)
        {
            this.price = newPrice;
        }
    }
}
