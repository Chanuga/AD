using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AD.Models.Admin
{
    public class SavePlayercs
    {
        public int ID { get; set; }
        public string AuctionName { get; set; }
        public int AuctionID { get; set; }
        public string PlayerName { get; set; }
        public int PlayerID { get; set; }
        public int SoldPrice { get; set; }
        public string TeamBought { get; set; }
    }
}
