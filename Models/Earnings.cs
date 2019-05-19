using System.Collections.Generic;

namespace Boreass.Models
{
    public class Earnings
    {
        public class List
        {
            public int Month { get; set; }
            public double Earning { get; set; }
        }
        public int StationId { get; set; }
        public List<List> monthList { get; set; }
        public Earnings()
        {
            monthList = new List<List>();
        }
    }
}
