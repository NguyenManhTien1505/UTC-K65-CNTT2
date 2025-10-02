using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Day06Annotation.Models
{
    public class Product : IValidatableObject
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự")]
        public string Name { get; set; }

        public string Image { get; set; }


        [Required(ErrorMessage = "Giá là bắt buộc")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá phải ít nhất 100000")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Giá khuyến mãi là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được âm")]
        public decimal SalePrice { get; set; }


        [StringLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Danh mục là bắt buộc")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SalePrice < 0)
            {
                yield return new ValidationResult("Giá khuyến mãi không được âm", new[] { nameof(SalePrice) });
            }


            if (Price > 0 && SalePrice > Price * 0.9m)
            {
                yield return new ValidationResult("Giá khuyến mãi phải nhỏ hơn giá chuẩn ít nhất 10%", new[] { nameof(SalePrice) });
            }


            if (!string.IsNullOrWhiteSpace(Description))
            {
                var lower = Description.ToLowerInvariant();
                var banned = new[] { "die", "admin", "fack", "fuck" };
                foreach (var w in banned)
                {
                    if (lower.Contains(w))
                        yield return new ValidationResult($"Mô tả chứa từ không hợp lệ: '{w}'", new[] { nameof(Description) });
                }
            }
        }
    }
}