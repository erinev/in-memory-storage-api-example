using System;
using System.Collections.Generic;
using InMemory.Storage.Api.Host.Interfaces;
using InMemory.Storage.Api.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace InMemory.Storage.Api.Host.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), 201)]
        public IActionResult Add([FromBody] NewProduct newProduct)
        {
            Product addedProduct = _productRepository.Add(newProduct);

            return CreatedAtAction(nameof(GetList), addedProduct);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        public IActionResult GetList()
        {
            IEnumerable<Product> products = _productRepository.GetList();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(typeof(Product), 200)]
        public IActionResult GetById(Guid id)
        {
            Product product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(typeof(Product), 200)]
        public IActionResult Update(Guid id, [FromBody] UpdatedProduct productToUpdate)
        {
            Product updatedProduct = _productRepository.Update(id, productToUpdate);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [ProducesResponseType(204)]
        public IActionResult Remove(Guid id)
        {
            bool removed = _productRepository.Remove(id);

            if (!removed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
