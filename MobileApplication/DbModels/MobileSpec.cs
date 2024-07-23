using System;
using System.Collections.Generic;

namespace MobileApplication.DbModels;

public partial class MobileSpec
{
    public int MobileSpecsId { get; set; }

    public int? MobileInfoId { get; set; }

    public string? Ram { get; set; }

    public string? Storage { get; set; }

    public string? Cpu { get; set; }

    public string? ChargingInfo { get; set; }

    public string? Cameras { get; set; }

    public string? Battery { get; set; }

    public string? Sensors { get; set; }

    public virtual MobileInfo? MobileInfo { get; set; }
}
