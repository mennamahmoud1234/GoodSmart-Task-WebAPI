using GoodSmart_Task.Data;
using GoodSmart_Task.Data.Models;

namespace GoodSmart_Task.HelpersMethod
{
    public class ProductMethods
    {
        private readonly AppDbContext _dbContext;

        public ProductMethods(AppDbContext dbContext) {
            _dbContext = dbContext;
        }
        #region GetAllProduct

        public IEnumerable<Product> GetAll()
        {
            var products = _dbContext.Products.ToList();
            return products;
        }
        #endregion


        #region GetSpecificProduct
        public Product? GetById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
            
        }
        #endregion


        #region AddProduct

        public Product Add(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        } 
        #endregion


        #region DeleteProduct 
        public Product Delete(int Id)
        {
            var product = _dbContext.Products.Find(Id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();

            }

            return product;
        } 
        #endregion


        #region  UpdateProduct 
        public Product update(int Id, Product product)
        {  
            var prod = _dbContext.Products.Find(Id);
            // if form not change 
            if (Id == prod?.Id && prod.Name == product.Name && prod.ExpiryDate == product.ExpiryDate)
            {
                return prod;
            }
             // update 
            if (prod != null)
            {
                prod.Price = product.Price;
                prod.ExpiryDate = product.ExpiryDate;
                prod.Name = product.Name;
                _dbContext.Update(prod);
                _dbContext.SaveChanges();

              
            }
            return prod;

        }
        #endregion



        #region GETNameOFProduct

         public Product? GetProductName(string productName)
        {
          var product=  _dbContext.Products.Where(P=>P.Name== productName).FirstOrDefault();
            return product;
        }
        #endregion

    }
}
