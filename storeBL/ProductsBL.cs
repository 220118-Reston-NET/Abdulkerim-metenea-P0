using storeDL;
using storeModel;
namespace storeBL
{
    public class ProductsBL : IProductsBL
    {
        private ProductSQLRepo _repo;
        public ProductsBL(ProductSQLRepo p_repo)
        {
            _repo = p_repo;
        }

        public List<Products> GetAllProduct()
        {
            List<Products> ListOfProducts = _repo.GetAllProduct();
            return ListOfProducts;
        }
        public Products AddProduct(Products p_product)
        {
            List<Products> listOfProduct = _repo.GetAllProduct();
            if(listOfProduct.Count < 10)
            {
                return _repo.AddProduct(p_product);
            }
            else
            {
                Console.WriteLine("10 produc limited!");
            }
            return p_product;
        }
        public List<Products> SearchProduct(int p_productId)
        {
            List<Products> Product = _repo.GetAllProduct();
            return Product
            .Where(p=>p.ProductID == p_productId)
            .ToList();
        }

    }
}