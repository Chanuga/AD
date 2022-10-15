using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AD.Models.Admin
{
    public class Team
    {
        public int ID { get; set; }
        //[Required(ErrorMessage = "Please Enter The Name !")]
        //[Display(Name = "Player Email :")]
        public string Name { get; set; }
        public int MaxPrice { get; set; }
    }
}
