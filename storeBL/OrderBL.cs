// using System.Linq;
using storeDL;
using storeModel;
namespace storeBL
{   
     public class OrderBL : IOrderBL
    {
        private OrderSQLRepo _repo;
        public OrderBL(OrderSQLRepo p_repo)
        {
            _repo = p_repo;
        }

        public List<Orders> GetAllOrders()
        {
            List<Orders> ListOfOrders = _repo.GetAllOrders();
            return ListOfOrders;
        }
        public List<Orders> OrderHistoryByCustID(int p_CustID)
        {
                // List<Orders> ListOfOrders = _repo.GetAllOrders();
                // return ListOfOrders
                // .Where(Orders => Orders.CustID == p_CustID)
                // .ToList();
                return _repo.OrderHistoryByCustID(p_CustID);
         
        }
    
        public void PlaceOrder(int p_custId, int p_storeId,int  p_totalprice , List<LineItems> p_cart)
        {
             _repo.PlaceOrder(p_custId,p_storeId, p_totalprice, p_cart);
            
        }

    }
}