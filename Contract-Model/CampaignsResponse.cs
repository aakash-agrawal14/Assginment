using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAssignment.Contract_Model
{
    public class CampaignsResponse
    {
        public string title { get; set; }
        public DateTime endDate { get; set; }
        public double backersCount { get; set; }
        public double totalAmount { get; set; }
    }
}
