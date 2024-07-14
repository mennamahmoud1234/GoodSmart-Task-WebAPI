using GoodSmart_Task.Data.Models;
using GoodSmart_Task.HelpersMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodSmart_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductMethods _productMethods;

        public ProductController(ProductMethods productMethods)
        {
            _productMethods = productMethods;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
          var products=  _productMethods.GetAll();
            if (products == null) {
                return new List<Product>();
            }
            return Ok(products);
        }
        [HttpGet("{Id}")]
        public  ActionResult<Product> Get(int Id) { 
          
          var product = _productMethods.GetById(Id);
            if(product == null)
            {
                return NotFound($"This Id {Id} not  exist");

            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product) {
            if (_productMethods.GetProductName(product.Name) != null)
            {
                return NotFound($"This {product.Name} already exist");
            }
            var CreatedProduct=  _productMethods.Add(product);
            return Ok(CreatedProduct);

        }


        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            var DeletedProduct = _productMethods.Delete(Id);
            if (DeletedProduct == null)
            {
                return NotFound($"Product with ID {Id} not found");
            }
            return Ok("Deleted Successfuly");

        }
        [HttpPut("{Id}")]

        public ActionResult<Product> Update(int Id, [FromBody] Product product)
        {

            var productName = _productMethods.GetProductName(product.Name);
            if (productName is not null && productName.Id!=Id  )
            {
                return NotFound($"This {product.Name} already exist");
            }
           
            var UpdatedProduct = _productMethods.update(Id,product);
            if (UpdatedProduct == null)
            {
                return NotFound($"Product with ID {Id} not found");
            }
            return Ok(UpdatedProduct);

        }

    }

}
