using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using API.Model.Products;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductModel model;

        public ProductsController(IProductModel model)
        {
            this.model = model;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProductAsync([FromBody] Product product)
        {
            try
            {
                var productAsync = await model.CreateProductAsync(product);
                return Ok(productAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync([FromRoute] int id)
        {
            try
            {
                var productByIdAsync = await model.GetProductByIdAsync(id);
                return Ok(productByIdAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }

        [HttpGet("/companies/{id:int}/products")]
        public async Task<ActionResult<IList<Product>>> GetCompanyProductsAsync([FromRoute] int id, [FromQuery] int? size, int? page)
        {
            try
            {
                IList<Product> companyProductsAsync;
                if (size.HasValue && page.HasValue)
                {
                    companyProductsAsync = await model.GetPagedCompanyProductsAsync(id, size.Value, page.Value);
                }
                else
                {
                  companyProductsAsync  = await model.GetCompanyProductsAsync(id);
                    
                }
                return Ok(companyProductsAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProductAsync([FromRoute] int id){
            try
            {
                var deleteProductAsync = await model.DeleteProductAsync(id);
                return Ok(deleteProductAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProductAsync([FromRoute] int id, [FromBody] Product product)
        {
            try
            {
                var updateProductAsync = await model.UpdateProductAsync(id, product);
                return Ok(updateProductAsync);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(403, e.Message);
            }
        }
        
        
    }
}