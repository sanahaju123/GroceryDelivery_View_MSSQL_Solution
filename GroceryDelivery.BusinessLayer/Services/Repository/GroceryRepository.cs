using GroceryDelivery.DataLayer;
using GroceryDelivery.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDelivery.BusinessLayer.Services.Repository
{
    public class GroceryRepository : IGroceryRepository
    {
        /// <summary>
        /// Creating Referance variable of GroceryDbContext
        /// Injecting in GroceryRepository constructor
        /// </summary>
        private readonly GroceryDbContext _groceryContext;

        public GroceryRepository(GroceryDbContext groceryDbContext)
        {
            _groceryContext = groceryDbContext;
        }
        /// <summary>
        /// Add new product in InMemoryDb
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                var result = _groceryContext.Products.Add(product);
                await  _groceryContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
        /// <summary>
        /// Get All product and product by id also
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            try
            {
                var result = _groceryContext.Products.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int? ProductId)
        {
            try
            {
                return await _groceryContext.Products.FindAsync(ProductId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
       
      
        /// <summary>
        /// Place order
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ProductOrder> PlaceOrder(ProductOrder order)
        {
            try
            {
                var result = await _groceryContext.productOrders.AddAsync(order);
                await _groceryContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Find Product by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> ProductByName(string name)
        {
            try
            {
                return (IEnumerable<Product>)await _groceryContext.Products.FindAsync(name);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Order Information of ordered product
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductOrder>> OrderByuserId(int UserId)
        {
            try
            {
                return (IEnumerable<ProductOrder>)await _groceryContext.productOrders.FindAsync(UserId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Product> DeleteProductById(int ProductId)
        {
            try
            {
                var prod = await _groceryContext.Products.FindAsync(ProductId);
                _groceryContext.Products.Remove(prod);
                await _groceryContext.SaveChangesAsync();
                return prod;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
             try
            {
                var prod = await _groceryContext.Products.FindAsync(product.ProductId);
                if (prod != null)
                {
                    _groceryContext.Products.Update(product);
                    await _groceryContext.SaveChangesAsync();
                    
                }
                return prod;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
