using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem
{
    public class FiveDollarsOffEveryHundreds : ICouponBehaviour
    {
        private const double DISCOUNT_AMOUNT = 5;
        private const string NAME = "$5 off every $100";

        double ICouponBehaviour.GetDiscountAmount(double currentOrderTotal)
        {
            int remainder = (int) currentOrderTotal / 100; // e.g. $345 / 100 = 3
            return remainder * DISCOUNT_AMOUNT; // e.g. discountedPrice = originalPrice - 3 * 5
        }

        public string GetName()
        {
            return NAME;
        }
    }
}
