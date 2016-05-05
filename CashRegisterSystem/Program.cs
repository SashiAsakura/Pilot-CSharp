using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world.");

            PurchaseOrder customer1 = new PurchaseOrder(0.15);
            customer1.AddItem(new Apple(7));
            customer1.AddItem(new Apple(10));
            customer1.AddItem(new Apple(8));
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Apple(8));
            
            customer1.ApplyBulkDiscount(new BuyThreeGetOneFree(Items.Cheerios));
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds());
            double totalPrice = customer1.GetTotalPrice();

            Console.WriteLine("total Price= $" + totalPrice);
        }
    }
}
