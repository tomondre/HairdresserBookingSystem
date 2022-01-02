﻿using System;
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
        public async Task<ActionResult<Product>> GetProductByIdAsync([FromQuery] int id)
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
        
    }
}