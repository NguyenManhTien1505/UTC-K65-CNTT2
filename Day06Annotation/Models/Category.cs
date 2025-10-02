using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Day06Annotation.Models
{
    public class Category
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Tên danh mục phải từ 2 đến 150 ký tự")]
        public string Name { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}