using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst1710.Models
{
    [Table("TvcLoai_San_Pham")]
    [Index(nameof(tvcMaLoai), IsUnique = true)]
    public class TvcLoai_San_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long tvcId { get; set; }
        [Display(Name = "Mã loại")]
        [StringLength(10)]
        public string tvcMaLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public string tvcTrangThai { get; set; }
        public ICollection<TvcSan_Pham>? tvcSan_Phams { get; set; }
    }
}
