// using System.Linq;
using storeModel;
namespace storeBL
{
    public interface IOrderBL
    {   
        List<Orders> GetAllOrders();
        List<Orders> OrderHistoryByCustID(int P_CustID);
       void PlaceOrder(int p_custId , int p_storeId , int p_totalPrice, List<LineItems> p_cart);
       
    }
}