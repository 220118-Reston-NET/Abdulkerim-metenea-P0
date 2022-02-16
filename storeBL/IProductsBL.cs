using storeModel;
namespace storeBL
{
    public interface IProductsBL
    {
        List<Products> GetAllProduct();
        Products AddProduct(Products p_product);
        List<Products> SearchProduct(int p_productId);
    
    }
}