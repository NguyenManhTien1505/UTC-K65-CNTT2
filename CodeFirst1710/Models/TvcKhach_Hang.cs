using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst1710.Models
{
    [Table("TvcKhach_Hang")]
    public class TvcKhach_Hang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tvcId { get; set; } // Khóa chính (ID)

        [Display(Name = "Mã khách hàng")]
        [Required]
        [StringLength(20)]
        public string tvcMaKhachHang { get; set; }

        [Display(Name = "Họ tên")]
        [StringLength(100)]
        public string? tvcHoTenKhachHang { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [StringLength(100)]
        public string? tvcEmail { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required]
        [StringLength(50)]
        public string tvcMatKhau { get; set; }

        [Display(Name = "Điện thoại")]
        [Phone]
        [StringLength(15)]
        public string? tvcDienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? tvcDiaChi { get; set; }

        [Display(Name = "Ngày đăng ký")]
        [DataType(DataType.Date)]
        public DateTime? tvcNgayDangKy { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string? tvcTrangThai { get; set; }

        // Thuộc tính điều hướng
        public ICollection<TvcHoa_Don>? tvcHoaDons { get; set; }
    }
}
