using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AD.Models.Admin;
using System.Data.SqlClient;

namespace AD.Controllers.Admin
{
    public class AdminLoginController : Controller
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
            con.ConnectionString = "Data Source=DESKTOP-ES9JH7P;Initial Catalog=ESPORTS;Integrated Security=True";
        }

        [HttpPost]
        public IActionResult VerifyCredntials(AdminLogin adminLogin)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Admin where user_name='" + adminLogin.UserName + "' and password = '" + adminLogin.Password + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Dashboard");
            }
            else
            {
                con.Close();
                return View("Home Page");
            }
            //return View();
        }

        public IActionResult CreateAdmin()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateNewAdmin(SignIn signIn)
        {
            Console.WriteLine("SignIn", signIn.UserName, signIn.Email, signIn.Password, signIn.PhoneNumber);
            //return View();
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO Admin (user_name, password, email, phone_number) VALUES ('" + signIn.UserName + "', '" + signIn.Password + "', '" + signIn.Email + "', '" + signIn.PhoneNumber + "') ";
            dr = com.ExecuteReader();
            con.Close();
            return View("Dashboard");
            //if (dr.Read())
            //{
            //    con.Close();
            //    return View("Dashboard");
            //}
            //else
            //{
            //    con.Close();
            //    return View("Error");
            //}
            //string query1 = "INSERT INTO Admin (user_name, password, email, phone_number) VALUES ('" + signIn.UserName + "', '" + signIn.Password + "', '" + signIn.Email + "', '" + signIn.PhoneNumber + "') ";
            //SqlCommand cmd1 = new SqlCommand(query1, con);

            //SqlConnection conn = new SqlConnection("Data Source = DESKTOP - ES9JH7P; Initial Catalog = ESPORTS; Integrated Security = True");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("INSERT INTO Admin (user_name, password, email, phone_number) VALUES ('" + signIn.UserName + "', '" + signIn.Password + "', '" + signIn.Email + "', '" + signIn.PhoneNumber + "') ");
            //cmd.ExecuteNonQuery();

            //return View("Dashboard");
        }



    }
}
