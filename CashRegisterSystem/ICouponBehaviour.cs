namespace CashRegisterSystem
{
    public interface ICouponBehaviour
    {
        double GetDiscountAmount(double currentOrderTotal);
        string GetName();
    }
}