using System;
using System.Collections.Generic;

namespace Boreass.Models.DbModels
{
    public partial class Tribunes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public double? Altitude { get; set; }
        public double? Potential { get; set; }
        public int? StationId { get; set; }
    }
}
