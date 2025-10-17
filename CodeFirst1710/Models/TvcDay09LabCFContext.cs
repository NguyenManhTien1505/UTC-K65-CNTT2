using Microsoft.EntityFrameworkCore;
using CodeFirst1710.Models;

namespace CodeFirst1710.Models
{
    public class TvcDay09LabCFContext : DbContext
    {
        public TvcDay09LabCFContext() { }
        public TvcDay09LabCFContext(DbContextOptions<TvcDay09LabCFContext> options) : base(options) { }
        public DbSet<TvcLoai_San_Pham> tvcLoai_San_Phams { get; set; }
        public DbSet<TvcSan_Pham> tvcSan_Phams { get; set; }
        public DbSet<CodeFirst1710.Models.TvcQuan_Tri> TvcQuan_Tri { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Đặt khóa chính tổng hợp cho bảng TvcCT_Hoa_Don
            // Khóa chính là sự kết hợp của tvcHoaDonID và tvcSan_PhamID
            modelBuilder.Entity<TvcCT_Hoa_Don>()
                .HasKey(ct => new { ct.tvcHoaDonID, ct.tvcSan_PhamID });

            // KHÔNG BẮT BUỘC, nhưng nên thêm nếu bạn chưa làm (như đã thảo luận trước)
            // Cấu hình rõ ràng các mối quan hệ 
            modelBuilder.Entity<TvcCT_Hoa_Don>()
                .HasOne(ct => ct.tvcHoaDon)
                .WithMany(hd => hd.tvcCT_HoaDons)
                .HasForeignKey(ct => ct.tvcHoaDonID);

            modelBuilder.Entity<TvcCT_Hoa_Don>()
                .HasOne(ct => ct.tvcSan_Pham)
                .WithMany(sp => sp.tvcCT_HoaDons) // Giả định bạn đã thêm collection này vào TvcSan_Pham
                .HasForeignKey(ct => ct.tvcSan_PhamID);

            // Đảm bảo bạn gọi base method
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CodeFirst1710.Models.TvcKhach_Hang> TvcKhach_Hang { get; set; } = default!;
        public DbSet<CodeFirst1710.Models.TvcHoa_Don> TvcHoa_Don { get; set; } = default!;
        public DbSet<CodeFirst1710.Models.TvcCT_Hoa_Don> TvcCT_Hoa_Don { get; set; } = default!;
    }

}
