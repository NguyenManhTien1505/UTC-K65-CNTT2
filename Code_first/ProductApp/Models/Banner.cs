using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Banner
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Image { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool Status { get; set; }
    }
}
