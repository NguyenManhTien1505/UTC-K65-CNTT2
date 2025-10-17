using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst1710.Models
{
    [Table("TvcQuan_Tri")]
    public class TvcQuan_Tri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tvcId { get; set; } // Khóa chính (ID)

        [Display(Name = "Tài khoản")]
        [Required]
        [StringLength(50)]
        public string tvcTaiKhoan { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required]
        [StringLength(50)]
        public string tvcMatKhau { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string? tvcTrangThai { get; set; }
    }
}
