using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst1710.Models
{
    [Table("TvcCT_Hoa_Don")]
    public class TvcCT_Hoa_Don
    {
        // Khóa ngoại 1: HoaDonID
        public int tvcHoaDonID { get; set; }
        [ForeignKey(nameof(tvcHoaDonID))]
        public TvcHoa_Don? tvcHoaDon { get; set; }

        // Khóa ngoại 2: SanPhamID (tên trong DB là ID)
        public int tvcSan_PhamID { get; set; }
        [ForeignKey(nameof(tvcSan_PhamID))]
        public TvcSan_Pham? tvcSan_Pham { get; set; }

        // Thuộc tính [Key] sẽ được áp dụng cho cả hai trường trên (composite key)
        // Dùng [Key, Column(Order=X)] nếu không định nghĩa trong DbContext

        [Display(Name = "Số lượng mua")]
        public int tvcSoLuongMua { get; set; }

        [Display(Name = "Đơn giá mua")]
        public decimal tvcDonGiaMua { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal tvcThanhTien { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string? tvcTrangThai { get; set; }
    }
}
