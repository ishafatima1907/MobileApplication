using MobileApplication.Manager.DTOs;
using System;
using System.Collections.Generic;

namespace MobileApplication.DbModels;

public partial class MobileInfoResponseModel
{
   public IEnumerable<MobileInfoDto> MobileInfos { get; set; }
}
