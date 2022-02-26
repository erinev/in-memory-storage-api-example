using System;
using System.Collections.Generic;
using System.Linq;
using InMemory.Storage.Api.Host.Interfaces;
using InMemory.Storage.Api.Host.Models;

namespace InMemory.Storage.Api.Host.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private List<Product> _products;

        public InMemoryProductRepository()
        {
            _products = new List<Product>();
        }

        public Product Add(NewProduct newProduct)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = newProduct.Title,
                Price = newProduct.Price,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _products.Add(product);

            return product;
        }

        public IEnumerable<Product> GetList()
        {
            return _products;
        }

        public Product GetById(Guid id)
        {
            return _products.SingleOrDefault(p => p.Id == id);
        }

        public Product Update(Guid id, UpdatedProduct updatedProduct)
        {
            Product productToUpdate = GetById(id);

            if (productToUpdate == null)
            {
                return null;
            }

            _products.RemoveAll(p => p.Id == id);

            productToUpdate.Title = updatedProduct.Title;
            productToUpdate.Price = updatedProduct.Price;
            productToUpdate.UpdatedAt = DateTime.UtcNow;

            _products.Add(productToUpdate);

            return productToUpdate;

        }

        public bool Remove(Guid id)
        {
            Product productToUpdate = GetById(id);

            if (productToUpdate == null)
            {
                return false;
            }

            _products.RemoveAll(p => p.Id == id);

            return true;
        }
    }
}