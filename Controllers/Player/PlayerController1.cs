using Microsoft.AspNetCore.Mvc;
using AD.Models;
using System.Data.SqlClient;
namespace AD.Controllers

{
    public class PlayerController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source=DESKTOP-HBTQOKA;Initial Catalog=ESPORTS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        [HttpPost]
        public ActionResult Verify(Playerregister player)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from player_registration where email='" + player.email + "' and password = '" + player.password + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Playerdashboard");
            }
            else
            {
                con.Close();
                return View("Home Page");
            }
        }
        public IActionResult Playerregister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Playerregister(Playerregister playerregister)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO player_registration (firstname,lastname,age,battingstyle,bowlingstyle,email,education,nationality,image,password) VALUES ('" + playerregister.firstname + "', '" + playerregister.lastname + "', '" + playerregister.age + "', '" + playerregister.battingstyle + "','" + playerregister.bowlingstyle + "','" + playerregister.email + "', '" + playerregister.education + "', '" + playerregister.nationality + "', '" + playerregister.image + "', '" + playerregister.password + "') ";
            dr = com.ExecuteReader();
            con.Close();
            return View("Playerdashboard");
        }
    }
}
