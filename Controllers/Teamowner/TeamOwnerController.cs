using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using AD.Models.Teamowner;
using Microsoft.AspNetCore.Http;
using System.Data;


namespace AD.Controllers.Teamowner
{
    public class TeamOwnerController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        string Str = @"Data Source=LDW-LAP;Initial Catalog=ESPORTS;Integrated Security=True";

        void connectionString()
        {
            con.ConnectionString = "Data Source=LDW-LAP;Initial Catalog=ESPORTS;Integrated Security=True";
        }




        // GET: TeamOwnerController
        public ActionResult Index()
        {
            return View();
        }

        //Player Login
        [HttpGet]
        public IActionResult TeamOwnerLogin()
        {
            return View();
        }


        //Player verify (login)
        [HttpPost]
        public IActionResult TeamOwnerLogin(Teamow teamlog)
        {
            Teamow obj = new Teamow();
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from TeamOwner where teamow_email='" + teamlog.teamow_email + "' and password = '" + teamlog.password + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Index");
            }
            else
            {
                con.Close();
                ViewData["message"] = "Email or Password incorrect!";
            }
            return View();
        }

        // GET: TeamOwnerController/Details/5 (view)
        public ActionResult Details(int id)
        {
            var teamowlist = new List<Teamow>();

            String constr = "Data Source=LDW-LAP;Initial Catalog=ESPORTS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                String sql = "SELECT * FROM TeamOwner";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Teamow tmo = new Teamow();
                            tmo.teamow_id = reader.GetInt32(0);
                            tmo.teamow_name = reader.GetString(1);
                            tmo.team_name = reader.GetString(2);
                            tmo.teamow_email = reader.GetString(3);
                            tmo.teamow_contact = reader.GetString(4);


                            teamowlist.Add(tmo);
                        }
                    }
                }
            }

            return View(teamowlist);
        }
    

        // GET: TeamOwnerController/Create
        public ActionResult TeamowCreate()
        {
            return View(new Teamow());
        }

        // POST: TeamOwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeamowCreate(Teamow teamo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Str))
                {
                    con.Open();
                    string q = "INSERT INTO TeamOwner VALUES ('" + teamo.teamow_name + "', '" + teamo.team_name + "', '" + teamo.teamow_email + "', '" + teamo.teamow_contact + "', '" + teamo.password + "')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamOwnerController/Edit/5
        public ActionResult Edit(int id)
        {

            Teamow teamo = new Teamow();
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "SELECT * FROM TeamOwner WHERE teamow_id=" + id;
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                da.Fill(dataTable);
            }
            if (dataTable.Rows.Count == 1)
            {
                teamo.teamow_id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                teamo.teamow_name = dataTable.Rows[0][1].ToString();
                teamo.team_name = dataTable.Rows[0][2].ToString();
                teamo.teamow_email = dataTable.Rows[0][3].ToString();
                teamo.teamow_contact = dataTable.Rows[0][4].ToString();
                teamo.password = dataTable.Rows[0][5].ToString();
                return View(teamo);

            }
            return RedirectToAction("Details");
        }


        // POST: TeamOwnerController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Teamow teamo)
        {
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "UPDATE TeamOwner SET teamow_name=@teamow_name,team_name=@team_name,teamow_email=@teamow_email,teamow_contact=@teamow_contact,password=@password WHERE teamow_id=@id";
                SqlCommand cmd = new SqlCommand(q, con);

                cmd.Parameters.AddWithValue("@id", teamo.teamow_id);
                cmd.Parameters.AddWithValue("@teamow_name", teamo.teamow_name);
                cmd.Parameters.AddWithValue("@team_name", teamo.team_name);
                cmd.Parameters.AddWithValue("@teamow_email", teamo.teamow_email);
                cmd.Parameters.AddWithValue("@teamow_contact", teamo.teamow_contact);
                cmd.Parameters.AddWithValue("@password", teamo.password);

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Details");
        }





        // GET: TeamOwnerController/Delete/5
        public ActionResult Delete(int id)
        {
            connectionString();
            con.Open();
            string query = "DELETE FROM TeamOwner WHERE teamow_id = @id ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            return RedirectToAction("Details");
        }

        // POST: TeamOwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
