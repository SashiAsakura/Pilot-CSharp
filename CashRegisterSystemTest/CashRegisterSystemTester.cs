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
    ///

    [TestClass]
    public class CashRegisterSystemTester
    {
        const double TAX_PERCENTAGE = 0.15;
        const double APPLE_PRICE = 12;
        const double CHEERIOS_PRICE = 130;
        const double MILK_PRICE = 3.5;
        const double ROBSTER_PRICE = 80;

        public CashRegisterSystemTester()
        {
        }

        /*
        Edge cases
        */

        [TestMethod]
        public void TestBuyNothinig()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            Assert.AreEqual(0, customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyNothinigButAddCouponsAndDiscount()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            customer1.ApplyBulkDiscount(new BuyTwoGerOneFree(Items.Apple));
            customer1.ApplyBulkDiscount(new BuyThreeGetOneFree(Items.Cheerios));
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds());
            Assert.AreEqual(0, customer1.GetTotalPrice());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Weight of apple can't be zero or negative.")]
        public void TestBuyNegativeAmountOfItems()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            customer1.AddItem(new Apple(-3)); // trying to buy an apple that weighs -3 lbs
        }

        /*
        Normal cases
        */

        [TestMethod]
        public void TestBuyOneApple()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            customer1.AddItem(new Apple(7));
            Assert.AreEqual(APPLE_PRICE * 7 * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyOneAppleOneCheerios()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            customer1.AddItem(new Apple(7));
            customer1.AddItem(new Cheerios());
            Assert.AreEqual((APPLE_PRICE * 7 + CHEERIOS_PRICE) * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyLotsOfItemInRandomOrder()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
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

            double expectedTotalBeforeTax = APPLE_PRICE * 7 + APPLE_PRICE * 10 + APPLE_PRICE * 8
                + APPLE_PRICE * 8 + CHEERIOS_PRICE * 8;
            Assert.AreEqual(expectedTotalBeforeTax * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyLotsOfItemInRandomOrderAndApplyCoupon()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
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
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds()); // total should be $1436 now before coupon

            double expectedTotalBeforeTax = APPLE_PRICE * 7 + APPLE_PRICE * 10 + APPLE_PRICE * 8
                + APPLE_PRICE * 8 + CHEERIOS_PRICE * 8;
            Assert.AreEqual((expectedTotalBeforeTax - 70) * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyLotsOfItemInRandomOrderAndApplyCouponAndBulkDiscount()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
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
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds()); // total should be $1176 now before coupon

            double expectedTotalBeforeTax = APPLE_PRICE * 7 + APPLE_PRICE * 10 + APPLE_PRICE * 8
                + APPLE_PRICE * 8 + CHEERIOS_PRICE * 6; // two free Cheerios
            Assert.AreEqual((expectedTotalBeforeTax - 55) * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyTwoCheeriosAndApplyBuyThreeGetOneFreeDiscount()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            customer1.AddItem(new Cheerios());
            customer1.AddItem(new Cheerios());
            customer1.ApplyBulkDiscount(new BuyThreeGetOneFree(Items.Cheerios));

            double expectedTotalBeforeTax = CHEERIOS_PRICE * 2;
            Assert.AreEqual(expectedTotalBeforeTax * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyLessThanHundredDollarsAndClaimCoupon()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            customer1.AddItem(new Apple(7));
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds());
            Assert.AreEqual(APPLE_PRICE * 7 * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestBuyMoreThanHundredDollarsAndClaimCoupon()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            customer1.AddItem(new Cheerios());
            customer1.ApplyCouponDeal(new FiveDollarsOffEveryHundreds());
            Assert.AreEqual((CHEERIOS_PRICE - 5) * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());
        }

        [TestMethod]
        public void TestMultipleCustomersInARow()
        {
            PurchaseOrder customer1 = new PurchaseOrder(TAX_PERCENTAGE);
            customer1.AddItem(new Apple(7));
            Assert.AreEqual(APPLE_PRICE * 7 * (1 + TAX_PERCENTAGE), customer1.GetTotalPrice());

            PurchaseOrder customer2 = new PurchaseOrder(TAX_PERCENTAGE);
            customer2.AddItem(new Cheerios());
            customer2.AddItem(new Cheerios());
            customer2.ApplyBulkDiscount(new BuyThreeGetOneFree(Items.Cheerios));

            double expectedTotalBeforeTax = CHEERIOS_PRICE * 2;
            Assert.AreEqual(expectedTotalBeforeTax * (1 + TAX_PERCENTAGE), customer2.GetTotalPrice());
        }
    }
}
