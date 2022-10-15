using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace AD.Models.Player
{
    public class Player
    {
        public int playerID { get; set; }

        [Required(ErrorMessage = "Please Enter The Email Address !")]
        [Display(Name = "Player Email :")]
        public string pemail { get; set; }


        [Required(ErrorMessage = "Enter Player Name !")]
        [Display(Name = "Enter Player Name :")]
        public string playename { get; set; }



        [Required(ErrorMessage = "Please Enter Password !")]
        [Display(Name = "Player Password :")]
        [DataType(DataType.Password)]
        public string password { get; set; }



        [Required(ErrorMessage = "Please Enter RePassword !")]
        [Display(Name = "Re-Password :")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string repassword { get; set; }
        


        [Required(ErrorMessage = "Enter Your Age !")]
        [Display(Name = "Player Age :")]
        public int age { get; set; }

        
       
        public string pimg { get; set; }

        [Required(ErrorMessage = "Enter Your are a Batsman or Bowler !")]
        [Display(Name = "Is Player Batsman or Bowler :")]
        public string bowler_or_batman { get; set; }

        [Required(ErrorMessage = "Enter Your Bating Style !")]
        [Display(Name = "Player Bating Style :")]
        public string battingstyle { get; set; }

        [Display(Name = "Player Bowling Style :")]
        public string bowlingstyle { get; set; }

        [Display(Name = "Player Matches :")]
        public int mtaches { get; set; }

        [Display(Name = "Player Wickets :")]
        public int witckets { get; set; }

        [Display(Name = "Player Runs :")]
        public int runs { get; set; }

        [Display(Name = "Player Participated Cups :")]
        public string previous_cup { get; set; }

        [Display(Name = "Select Thropy :")]
        public string thropy { get; set; }

    }
}
