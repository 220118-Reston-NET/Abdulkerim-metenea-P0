using storeModel;
namespace storeBL
{
    public interface ILineItemsBL
    {

        List<LineItems> GetAllLineItemsByOrderID(int p_OrderID);
        List<LineItems> ReduceQuantity(int productId, int quantity);
        
    }
}