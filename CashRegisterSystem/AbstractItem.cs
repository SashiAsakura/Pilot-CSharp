using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    abstract public class AbstractItem
    {
        protected double price;
        protected int itemID;
        protected string name;
        protected Items item;

        abstract public double GetPrice();

        public int GetItemID()
        {
            return this.itemID;
        }

        public String GetName()
        {
            return this.name;
        }

        public Items GetItem()
        {
            return this.item;
        }

    }
}
