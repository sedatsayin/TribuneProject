using System;
using System.Collections.Generic;

namespace Boreass.Models.DbModels
{
    public partial class EarningMonthly
    {
        public int Id { get; set; }
        public int? Month { get; set; }
        public double? Earning { get; set; }
        public int? StationId { get; set; }
    }
}
