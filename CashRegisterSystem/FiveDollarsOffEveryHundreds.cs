using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    public class FiveDollarsOffEveryHundreds : ICouponBehaviour
    {
        private double discountAmount = 5;
        private string name = "$5 off every $100";
        double ICouponBehaviour.GetDiscountAmount(double currentOrderTotal)
        {
            int remainder = (int) currentOrderTotal / 100; // e.g. $345 / 100 = 3
            return remainder * discountAmount; // e.g. discountedPrice = originalPrice - 3 * 5
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
