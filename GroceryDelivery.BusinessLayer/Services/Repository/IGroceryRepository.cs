using GroceryDelivery.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.BusinessLayer.Services.Repository
{
    public interface IGroceryRepository
    {
        //List of method to perform all related operation
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<ProductOrder> PlaceOrder(ProductOrder order);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int? ProductId);
        Task<Product> DeleteProductById(int ProductId);
        Task<IEnumerable<Product>> ProductByName(string name);
        Task<IEnumerable<ProductOrder>> OrderByuserId(int UserId);
    }
}
