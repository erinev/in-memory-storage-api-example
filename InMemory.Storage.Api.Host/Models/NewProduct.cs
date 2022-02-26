using System.ComponentModel.DataAnnotations;

namespace InMemory.Storage.Api.Host.Models
{
    public class NewProduct
    {
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Range(0.01, int.MaxValue)]
        public decimal Price { get; set; }
    }
}