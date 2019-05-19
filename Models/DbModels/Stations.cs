using System;
using System.Collections.Generic;

namespace Boreass.Models.DbModels
{
    public partial class Stations
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Potential { get; set; }
        public int? AreaId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Score { get; set; }
    }
}
