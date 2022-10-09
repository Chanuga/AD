using Microsoft.AspNetCore.Mvc;
using AD.Models;
using System.Data.SqlClient;
namespace AD.Controllers
{
    public class TeamOwnerController : Controller
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
            con.ConnectionString = "Data Source=LDW-LAP;Initial Catalog=ESPORTS;Integrated Security=True";
        }

        [HttpPost]
        public ActionResult Verify(TeamOwner teamOwner)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from team_owner where team_owner_email='"+teamOwner.email+"' and team_owner_password = '"+teamOwner.password+"' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("TeamDashboard");
            }
            else
            {
                con.Close();
                return View("Home Page");
            }
        }
    }
}
