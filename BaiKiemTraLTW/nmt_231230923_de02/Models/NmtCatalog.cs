using System;
using System.Collections.Generic;

namespace nmt_231230923_de02.Models;

public partial class NmtCatalog
{
    public int NmtId { get; set; }

    public string? NmtCateName { get; set; }

    public decimal? NmtCatePrice { get; set; }

    public int? NmtCateQty { get; set; }

    public string? NmtPicture { get; set; }

    public bool? NmtCateActive { get; set; }
}
