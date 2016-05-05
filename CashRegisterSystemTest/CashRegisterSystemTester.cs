using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegisterSystem;

namespace CashRegisterSystemTest
{
    /// <summary>
    /// Summary description for CashRegisterSystemTester
    /// </summary>
    [TestClass]
    public class CashRegisterSystemTester
    {
        public CashRegisterSystemTester()
        {
        }

        [TestMethod]
        public void TestBuyOneApple()
        {
            PurchaseOrder customer1 = new PurchaseOrder(0.15);
            customer1.AddItem(new Apple(7));
            Assert.AreEqual(12 * 7 * 1.15, customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyLessThanHundredDollarsAndClaimCoupon()
        {
            PurchaseOrder customer1 = new PurchaseOrder(0.15);
            customer1.AddItem(new Apple(7));
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds());
            Assert.AreEqual(12 * 7 * 1.15, customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyMoreThanHundredDollarsAndClaimCoupon()
        {
            PurchaseOrder customer1 = new PurchaseOrder(0.15);
            customer1.AddItem(new Cheerios());
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds());
            Assert.AreEqual((130 - 5) * 1.15, customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyOneAppleOneCheerios()
        {
            PurchaseOrder customer1 = new PurchaseOrder(0.15);
            customer1.AddItem(new Apple(7));
            customer1.AddItem(new Cheerios());
            Assert.AreEqual((12 * 7 + 130) * 1.15, customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyNothinig()
        {
            PurchaseOrder customer1 = new PurchaseOrder(0.15);
            Assert.AreEqual(0, customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyNothinigButAddCouponsAndDiscount()
        {
            PurchaseOrder customer1 = new PurchaseOrder(0.15);
            customer1.ApplyBulkDiscount(new BuyTwoGerOneFree(Items.Apple));
            customer1.ApplyBulkDiscount(new BuyThreeGetOneFree(Items.Cheerios));
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds());
            Assert.AreEqual(0, customer1.GetTotalPrice());
        }
    }
}
