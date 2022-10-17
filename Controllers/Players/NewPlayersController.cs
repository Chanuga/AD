using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using AD.Models.Player;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace AD.Controllers.Players
{
    public class NewPlayersController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        string Str = @"Data Source=LDW-LAP;Initial Catalog=ESPORTS;Integrated Security=True";

        void connectionString()
        {
            con.ConnectionString = "Data Source=LDW-LAP;Initial Catalog=ESPORTS;Integrated Security=True";
        }

        //Player Dashboard
        public IActionResult PlayerDashboard()
        {
            return View();
        }

        //Player Login
        [HttpGet]
        public IActionResult PlayerLogin()
        {
            return View();
        }


        //Player verify
        [HttpPost]
        public IActionResult PlayerLogin(Player plrlog)
        {
            Player obj = new Player(); 
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Player where pemail='" + plrlog.pemail + "' and password = '" + plrlog.password + "' ";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("PlayerDashboard");
            }
            else
            {
                con.Close();
                ViewData["message"] = "Email or Password incorrect!";
            }
            return View();
        }








        // GET: Player/Create
        [HttpGet]
        public IActionResult PlayerCreate()
        {
            return View(new Player());
        }

        // POST: Player/Create
        [HttpPost]
        public IActionResult PlayerCreate(Player nplayer)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Str))
                {
                    con.Open();
                    string q = "INSERT INTO Player VALUES ('" + nplayer.pemail + "', '" + nplayer.playename + "', '" + nplayer.password + "', '" + nplayer.age + "' , '" + nplayer.pimg + "', '" + nplayer.bowler_or_batman + "','" + nplayer.battingstyle + "',  '" + nplayer.bowlingstyle + "',  '" + nplayer.mtaches + "',  '" + nplayer.witckets + "', '" + nplayer.runs + "', '" + nplayer.previous_cup + "')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("PlayerList");
            }
            catch
            {
                return View();
            }
            
        }


        // GET Player/Registration
        public IActionResult PlayerReg()
        {
            return View();
        }

        // POST Player/Registration
        [HttpPost]
        public IActionResult PlayerReg(Player nplayer, IFormFile file)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO Player (pemail,playename,password,age,pimg,bowler_or_batman,battingstyle,bowlingstyle,mtaches,witckets,runs,previous_cup,thropy,base_price,status) VALUES ('" + nplayer.pemail + "', '" + nplayer.playename + "', '" + nplayer.password + "', '" + nplayer.age + "' , '" + nplayer.pimg + "', '" + nplayer.bowler_or_batman + "','" + nplayer.battingstyle + "',  '" + nplayer.bowlingstyle + "',  '" + nplayer.mtaches + "',  '" + nplayer.witckets + "', '" + nplayer.runs + "', '" + nplayer.previous_cup + "', '" + nplayer.thropy + "',0,0 ) ";
            dr = com.ExecuteReader();
            con.Close();
            ViewData["Message"] = "Player Record  " +  nplayer.playename + "Is Saved Successfully !";
            return View();
        }


        // Player/LIST VIEW
        public IActionResult PlayerList(int id)
        {
            var playerlist = new List<Player>();

            String constr = "Data Source=LDW-LAP;Initial Catalog=ESPORTS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                String sql = "SELECT * FROM Player";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Player plr = new Player();
                            plr.playerID = reader.GetInt32(0);
                            plr.pemail = reader.GetString(1);
                            plr.playename = reader.GetString(2);
                            plr.password = reader.GetString(3);
                            plr.age = reader.GetInt32(4);
                            plr.pimg = reader.GetString(5);
                            plr.bowler_or_batman = reader.GetString(6);
                            plr.battingstyle = reader.GetString(7);
                            plr.bowlingstyle = reader.GetString(8);
                            plr.mtaches = reader.GetInt32(9);
                            plr.witckets = reader.GetInt32(10);
                            plr.runs = reader.GetInt32(11);
                            plr.previous_cup = reader.GetString(12);


                            playerlist.Add(plr);
                        }
                    }
                }
            }

            return View(playerlist);
        }



        //DELETE ACTION 
        public IActionResult PlayerDelete(int player)
        {
            connectionString();
            con.Open();
            string query = "DELETE FROM Player WHERE playerID = @player ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@player", player);
            cmd.ExecuteNonQuery();

            return RedirectToAction("PlayerList");
        }


        // Get: Player/Edit
       
        public IActionResult PlayerEdit(int playerID)
        {
            Player player = new Player();
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "SELECT * FROM Player WHERE playerID=" + playerID;
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                da.Fill(dataTable);
            }
            if(dataTable.Rows.Count== 1)
            {
                player.playerID = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                player.pemail = dataTable.Rows[0][1].ToString();
                player.playename = dataTable.Rows[0][2].ToString();
                player.password = dataTable.Rows[0][3].ToString();
                player.age = Convert.ToInt32(dataTable.Rows[0][4].ToString());
                player.bowler_or_batman = dataTable.Rows[0][5].ToString();
                player.battingstyle = dataTable.Rows[0][6].ToString();
                player.bowlingstyle = dataTable.Rows[0][7].ToString();
                player.mtaches = Convert.ToInt32(dataTable.Rows[0][9].ToString());
                player.witckets = Convert.ToInt32(dataTable.Rows[0][10].ToString());
                player.runs = Convert.ToInt32(dataTable.Rows[0][11].ToString());
                player.previous_cup = dataTable.Rows[0][12].ToString();

                return View(player);

            }
            return RedirectToAction("PlayerList");

        }

        // Post: Player/Edit
        [HttpPost]
        public IActionResult PlayerEdit(int playerID, Player plr)
        {
            
                using (SqlConnection con = new SqlConnection(Str))
                {
                    con.Open();
                    string q = "UPDATE Player SET pemail=@pemail,playename=@playename,age=@age,bowler_or_batman=@bowler_or_batman,battingstyle=@battingstyle,bowlingstyle=@bowlingstyle,mtaches=@mtaches,witckets=@witckets,runs=@runs,previous_cup=@previous_cup WHERE playerID=@playerID";
                    SqlCommand cmd = new SqlCommand(q, con);

                    cmd.Parameters.AddWithValue("@playerID", plr.playerID);
                    cmd.Parameters.AddWithValue("@pemail", plr.pemail);
                    cmd.Parameters.AddWithValue("@playename", plr.playename);
                    cmd.Parameters.AddWithValue("@age", plr.age);
                    cmd.Parameters.AddWithValue("@bowler_or_batman", plr.bowler_or_batman);
                    cmd.Parameters.AddWithValue("@battingstyle", plr.battingstyle);
                    cmd.Parameters.AddWithValue("@bowlingstyle", plr.bowlingstyle);
                    cmd.Parameters.AddWithValue("@mtaches", plr.mtaches);
                    cmd.Parameters.AddWithValue("@witckets", plr.witckets);
                    cmd.Parameters.AddWithValue("@runs", plr.runs);
                    cmd.Parameters.AddWithValue("@previous_cup", plr.previous_cup);

                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("PlayerList");
            
            
        }



        // Player/LIST VIEW
        public IActionResult PlayerWatchList(int id)
        {
            var playerlist = new List<Player>();

            String constr = "Data Source=LDW-LAP;Initial Catalog=ESPORTS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                String sql = "SELECT * FROM Player";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Player plr = new Player();
                            plr.playerID = reader.GetInt32(0);
                            plr.pemail = reader.GetString(1);
                            plr.playename = reader.GetString(2);
                            plr.password = reader.GetString(3);
                            plr.age = reader.GetInt32(4);
                            plr.pimg = reader.GetString(5);
                            plr.bowler_or_batman = reader.GetString(6);
                            plr.battingstyle = reader.GetString(7);
                            plr.bowlingstyle = reader.GetString(8);
                            plr.mtaches = reader.GetInt32(9);
                            plr.witckets = reader.GetInt32(10);
                            plr.runs = reader.GetInt32(11);
                            plr.previous_cup = reader.GetString(12);


                            playerlist.Add(plr);
                        }
                    }
                }
            }

            return View(playerlist);
        }


        // Get: Player/Edit

        public IActionResult PlayerEditPlayer(int playerID)
        {
            Player player = new Player();
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "SELECT * FROM Player WHERE playerID=" + playerID;
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                da.Fill(dataTable);
            }
            if (dataTable.Rows.Count == 1)
            {
                player.playerID = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                player.pemail = dataTable.Rows[0][1].ToString();
                player.playename = dataTable.Rows[0][2].ToString();
                player.password = dataTable.Rows[0][3].ToString();
                player.age = Convert.ToInt32(dataTable.Rows[0][4].ToString());
                player.bowler_or_batman = dataTable.Rows[0][5].ToString();
                player.battingstyle = dataTable.Rows[0][6].ToString();
                player.bowlingstyle = dataTable.Rows[0][7].ToString();
                player.mtaches = Convert.ToInt32(dataTable.Rows[0][9].ToString());
                player.witckets = Convert.ToInt32(dataTable.Rows[0][10].ToString());
                player.runs = Convert.ToInt32(dataTable.Rows[0][11].ToString());
                player.previous_cup = dataTable.Rows[0][12].ToString();

                return View(player);

            }
            return RedirectToAction("PlayerDashboard");

        }

        // Post: Player/Edit
        [HttpPost]
        public IActionResult PlayerEditPlayer(int playerID, Player plr)
        {

            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "UPDATE Player SET pemail=@pemail,playename=@playename,age=@age,bowler_or_batman=@bowler_or_batman,battingstyle=@battingstyle,bowlingstyle=@bowlingstyle,mtaches=@mtaches,witckets=@witckets,runs=@runs,previous_cup=@previous_cup WHERE playerID=@playerID";
                SqlCommand cmd = new SqlCommand(q, con);

                cmd.Parameters.AddWithValue("@playerID", plr.playerID);
                cmd.Parameters.AddWithValue("@pemail", plr.pemail);
                cmd.Parameters.AddWithValue("@playename", plr.playename);
                cmd.Parameters.AddWithValue("@age", plr.age);
                cmd.Parameters.AddWithValue("@bowler_or_batman", plr.bowler_or_batman);
                cmd.Parameters.AddWithValue("@battingstyle", plr.battingstyle);
                cmd.Parameters.AddWithValue("@bowlingstyle", plr.bowlingstyle);
                cmd.Parameters.AddWithValue("@mtaches", plr.mtaches);
                cmd.Parameters.AddWithValue("@witckets", plr.witckets);
                cmd.Parameters.AddWithValue("@runs", plr.runs);
                cmd.Parameters.AddWithValue("@previous_cup", plr.previous_cup);

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("PlayerDashboard");


        }


    }
}
