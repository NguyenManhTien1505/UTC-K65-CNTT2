using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? SalePrice { get; set; }

        public int Status { get; set; }

        public string? Descriptions { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Liên kết Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
