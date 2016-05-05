using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    public class PurchaseOrder
    {
        private double currentOrderTotal;
        private Dictionary<Items, Int32> itemCounter;
        private ICouponBehaviour couponBehaviour;
        private double taxPercentage;

        public PurchaseOrder(double taxPercentage)
        {
            this.taxPercentage = taxPercentage;
            itemCounter = new Dictionary<Items, int>();
        }

        public void ApplyCouponDeal(ICouponBehaviour couponBehaviour)
        {
            Console.WriteLine("current order total is $" + this.currentOrderTotal);
            this.couponBehaviour = couponBehaviour;
            double discountAmount = this.couponBehaviour.GetDiscountAmount(this.currentOrderTotal);
            this.currentOrderTotal -= discountAmount;

            Console.WriteLine("applying a discount coupon " + this.couponBehaviour.GetName() 
                + ", discount= -$" + discountAmount);
        }

        public void ApplyBulkDiscount(IBulkDiscountBehaviour bulkDiscountBehaviour)
        {
            if (!this.itemCounter.ContainsKey(bulkDiscountBehaviour.GetItem()))
            {
                Console.WriteLine("Error: you are trying to claim bulk discount deal for the item you didn't add yet.");
                return;
            }

            double discountAmount = bulkDiscountBehaviour.GetDiscountAmount(this.itemCounter[bulkDiscountBehaviour.GetItem()]);
            this.currentOrderTotal -= discountAmount;
            Console.WriteLine("applying bulk discount " + bulkDiscountBehaviour.GetName() + " for " + bulkDiscountBehaviour.GetItem()
                + ", " + this.itemCounter[bulkDiscountBehaviour.GetItem()] + "x " + bulkDiscountBehaviour.GetItem() 
                + ", discount = -$" + discountAmount);
        }

        public void AddItem(AbstractItem newItem)
        {
            Console.WriteLine("adding " + newItem.GetName() + " $" + newItem.GetPrice());
            this.currentOrderTotal += newItem.GetPrice();

            Items key = newItem.GetItem();
            if (!this.itemCounter.ContainsKey(key))
            {
                this.itemCounter.Add(key, 0); // init value
            }

            this.itemCounter[key] += 1; // increment item counter by 1
        }

        // compute total including taxes
        public double GetTotalPrice()
        {
            Console.WriteLine("purchase price= $" + this.currentOrderTotal + ", tax " + this.taxPercentage
                + "% = $" + this.currentOrderTotal * this.taxPercentage);
            return this.currentOrderTotal * (1.0 + this.taxPercentage);
        }
    }
}
