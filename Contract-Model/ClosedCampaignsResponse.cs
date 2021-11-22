using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAssignment.Contract_Model
{
    public class ClosedCampaignsResponse
    {
        public string title { get; set; }
        public DateTime endDate { get; set; }
        public double procuredAmount { get; set; }
        public double totalAmount { get; set; }
    }
}
