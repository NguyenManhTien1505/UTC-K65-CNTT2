using System;
using System.Collections.Generic;

namespace BanHangDataFirst.Models;

public partial class QuanTri
{
    public int Id { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public bool? TrangThai { get; set; }
}
