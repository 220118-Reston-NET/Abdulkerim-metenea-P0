using storeModel;
namespace storeDL
{
    public interface ILineItemIRepo
    {
        List<LineItems> GetAllLineItemsByOrderID(int p_OrderID);
        List<LineItems> GetAllineItems();
        List<LineItems> ReduceQuantity(int productId, int quantity);
       
    }
}