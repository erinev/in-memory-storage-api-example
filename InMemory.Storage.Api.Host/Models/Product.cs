using System;
using System.ComponentModel.DataAnnotations;

namespace InMemory.Storage.Api.Host.Models
{
    public class Product : NewProduct
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}