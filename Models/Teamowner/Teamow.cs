using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace AD.Models.Teamowner
{
    public class Teamow
    {
        public int teamow_id { get; set; }

        [Required(ErrorMessage = "Please Enter Team Owner Name !")]
        [Display(Name = "Team Owner Name :")]
        public string teamow_name { get; set; }

        [Required(ErrorMessage = "Please Enter Team Name !")]
        [Display(Name = "Team Name :")]
        public string team_name { get; set; }

        [Required(ErrorMessage = "Please Enter Team owner email !")]
        [Display(Name = "Team Owner Email :")]
        public string teamow_email { get; set; }

        [Required(ErrorMessage = "Please Enter Team owner conatct !")]
        [Display(Name = "Team Owner Contact :")]
        public string teamow_contact { get; set; }


        [Required(ErrorMessage = "Please Enter Team owner Password !")]
        [Display(Name = "Team Owner  Password :")]
        [DataType(DataType.Password)]
        public string password { get; set; }



        [Required(ErrorMessage = "Please Enter RePassword !")]
        [Display(Name = "Re-Password :")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string repassword { get; set; }

    }
}
