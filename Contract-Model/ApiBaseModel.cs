﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAssignment.Contract_Model
{
    public class ApiBaseModel
    {
        public string code { get; set; }
        public string title { get; set; }
        public bool featured { get; set; }
        public int priority { get; set; }
        public string campaignType { get; set; }
        public string shortDesc { get; set; }
        public object imageSrc { get; set; }
        public DateTime created { get; set; }
        public DateTime endDate { get; set; }
        public double totalAmount { get; set; }
        public double procuredAmount { get; set; }
        public double totalProcured { get; set; }
        public double backersCount { get; set; }
        public int categoryId { get; set; }
        public string location { get; set; }
        public string ngoCode { get; set; }
        public string ngoName { get; set; }
        public int daysLeft { get; set; }
        public double percentage { get; set; }

    }   
}
