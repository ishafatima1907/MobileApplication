using System;
using System.Collections.Generic;

namespace MobileApplication.DbModels;

public partial class MobileInfo
{
    public int MobileInfoId { get; set; }

    public string BrandName { get; set; } = null!;

    public string ModelName { get; set; } = null!;

    public int YearOfMake { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<MobileSpec> MobileSpecs { get; set; } = new List<MobileSpec>();
}
