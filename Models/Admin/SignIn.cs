using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AD.Models.Admin
{
    public class SignIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public DateTime CreatedAt { get; set; }
    }
}
