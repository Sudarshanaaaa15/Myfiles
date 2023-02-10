using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLib.Libraries
{
    public interface IProductDB
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetAllProducts();
    }
    public static class ProductFactory
    {
        public static IProductDB GetComponent() => new ProductDB();

        
    }
    class ProductDB : IProductDB
    {
        static ProductEntities context = new ProductEntities();
        public void AddProduct(Product product)
        {
         //var context = new ProductEntities();

            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            //var context = new ProductEntities();
            var foundProduct = context.Products.FirstOrDefault((p) => p.ProductId == id);
            context.Products.Remove(foundProduct);
            context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
           // var context = new ProductEntities();
            var foundProduct = context.Products.First((p) => p.ProductId == product.ProductId);
            foundProduct.ProductIamge = product.ProductIamge;
            foundProduct.ProductName = product.ProductName;
            foundProduct.ProductPrice = product.ProductPrice;
            foundProduct.Quantity = product.Quantity;
            context.SaveChanges();
        }
        public List<Product> GetAllProducts() => context.Products.ToList();
    } 
}
