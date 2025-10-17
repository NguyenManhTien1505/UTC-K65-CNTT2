using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst1710.Models
{
    [Table("TvcSan_Pham")]
    public class TvcSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tvcId { get; set; }

        [Display(Name = " Mã sản phẩm")]
        [Required]
        [StringLength(10)]
        public string tvcMaSanPham { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string tvcTenSanPham { get; set; }
        [Display(Name = "Hình ảnh")]
        public string tvcHinhAnh { get; set; }
        [Display(Name = "Số lượng")]
        public int tvcSoLuong { get; set; }
        [Display(Name = "Đơn giá")]
        public decimal tvcDonGia { get; set; }
        public long tvcLoaiSanPhamId { get; set; }
        public TvcLoai_San_Pham? tvcLoai_San_Pham { get; set; }
        public ICollection<TvcCT_Hoa_Don>? tvcCT_HoaDons { get; set; }
    }
}
