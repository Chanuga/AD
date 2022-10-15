using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AD.Models.Admin
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string BasePrice { get; set; }
        public string TrophyRegistered { get; set; }
        public int Status { get; set; }
    }
}
