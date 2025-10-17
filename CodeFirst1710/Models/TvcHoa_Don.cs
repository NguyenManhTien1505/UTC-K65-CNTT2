using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst1710.Models
{
    [Table("TvcHoa_Don")]
    public class TvcHoa_Don
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tvcId { get; set; } // Khóa chính (ID)

        [Display(Name = "Mã hóa đơn")]
        [StringLength(20)]
        public string? tvcMaHoaDon { get; set; }

        // Khóa ngoại tới Khách hàng
        public int tvcMaKhachHang { get; set; }
        [ForeignKey(nameof(tvcMaKhachHang))]
        public TvcKhach_Hang? tvcKhachHang { get; set; }

        [Display(Name = "Ngày hóa đơn")]
        [DataType(DataType.Date)]
        public DateTime tvcNgayHoaDon { get; set; }

        [Display(Name = "Ngày nhận")]
        [DataType(DataType.Date)]
        public DateTime? tvcNgayNhan { get; set; }

        [Display(Name = "Họ tên khách hàng")]
        [StringLength(100)]
        public string? tvcHoTenKhachHang { get; set; }

        [Display(Name = "Email")]
        [StringLength(100)]
        public string? tvcEmail { get; set; }

        [Display(Name = "Điện thoại")]
        [StringLength(15)]
        public string? tvcDienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? tvcDiaChi { get; set; }

        [Display(Name = "Tổng trị giá")]
        public decimal tvcTongTriGia { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string? tvcTrangThai { get; set; }

        // Thuộc tính điều hướng
        public ICollection<TvcCT_Hoa_Don>? tvcCT_HoaDons { get; set; }
    }
}
