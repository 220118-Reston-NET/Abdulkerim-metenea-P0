using storeModel;

namespace storeDL
{
    public interface IOrderRepo
    {
        List<Orders> GetAllOrders();
        List<Orders> OrderHistoryByCustID(int P_CustID);
        void PlaceOrder(int p_custId, int p_storeId, int p_totalprice, List<LineItems> p_cart);
        //=............................................................................................

    }
}