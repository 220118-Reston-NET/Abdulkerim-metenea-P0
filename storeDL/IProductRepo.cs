using storeModel;
namespace storeDL
{
    public interface IProductRepo
    {
        List<Products> GetAllProduct();
        Products AddProduct(Products p_product);
        List<Products> SearchProduct(int p_productId);
    }
}