using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AD.Models.Admin
{
    public class PlayerAuction
    {
        public int ID { get; set; }
        public string AuctionName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
