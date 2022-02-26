using System;
using System.Collections.Generic;
using InMemory.Storage.Api.Host.Models;

namespace InMemory.Storage.Api.Host.Interfaces
{
    public interface IProductRepository
    {
        public Product Add(NewProduct newProduct);
        public IEnumerable<Product> GetList();
        public Product GetById(Guid id);
        public Product Update(Guid id, UpdatedProduct updatedProduct);
        public bool Remove(Guid id);
    }
}
