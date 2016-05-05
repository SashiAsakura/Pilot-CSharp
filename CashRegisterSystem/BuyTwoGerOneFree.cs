using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    public class BuyTwoGerOneFree : IBulkDiscountBehaviour
    {
        const int DISCOUNT_STEP = 3; // this is constant for buy two get one free => for every 3 items, get 1 item's price free
        private const string NAME = "Buy Two Get One Free";
        private Items item;

        public BuyTwoGerOneFree(Items item)
        {
            this.item = item;
        }

        public double GetDiscountAmount(int numOfOrders)
        {
            int numOfFreeItem = numOfOrders / DISCOUNT_STEP; // e.g. 5 / 3 = 1, meaning 1 item is free
            return numOfFreeItem * this.item.GetPrice(); // compute how much discount we get
        }

        public Items GetItem()
        {
            return this.item;
        }

        public string GetName()
        {
            return NAME;
        }
    }
}
