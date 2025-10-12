using System;
using System.Collections.Generic;

namespace BanHangDataFirst.Models;

public partial class LoaiSanPham
{
    public int Id { get; set; }

    public string? MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
