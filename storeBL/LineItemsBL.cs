
using storeDL;
using storeModel;
namespace storeBL
{
    public class LineItemsBL : ILineItemsBL

    {
        private LineItemSQLRepo _repo;
        public LineItemsBL(LineItemSQLRepo p_repo)
        {
            _repo = p_repo;

        }
        public List<LineItems> GetAllLineItemsByOrderID(int p_OrderID)
        {
            return _repo.GetAllLineItemsByOrderID(p_OrderID);
        }

        public List<LineItems> ReduceQuantity(int productId, int quantity)
        {
            List<LineItems> updatedQuantity = _repo.ReduceQuantity(productId,quantity);
            return updatedQuantity
            .Where(p => p.ProductID == productId && p.Quantity == quantity)
            .ToList();
        }
    }
}