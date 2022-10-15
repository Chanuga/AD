using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AD.Models.Admin;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AD.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ES9JH7P;Initial Catalog=ESPORTS;Integrated Security=True");

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
                return View("HomePage");
            }
            //return View();
        }

        public IActionResult Dashboard()
        {
            return View();
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

        public IActionResult CreateTrophy()
        {
            return View();
        }

        public IActionResult CreateNewTrophyV1()
        {
            //var t = new List<Trophy>();
            //for(int i = 1; i < 11; i++)
            //{
            //    t.Add(item: new Trophy()
            //    {
            //        Name = "test ${i}",
            //        EndDate = "2022-10",
            //        StartDate = "2022-12",
            //        Teams = 8
            //    });
            //}
            //return View(t);

            var t = new List<Trophy>();

            String constr = "Data Source=DESKTOP-ES9JH7P;Initial Catalog=ESPORTS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                String sql = "SELECT * FROM Trophy";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Trophy tro = new Trophy();
                            tro.ID = reader.GetInt32(0);
                            tro.Name = reader.GetString(1);
                            tro.StartDate = reader.GetDateTime(2).ToString();
                            tro.EndDate = reader.GetDateTime(3).ToString();
                            tro.Teams = reader.GetInt32(4);

                            t.Add(tro);
                        }
                    }
                }
            }

            return View(t);
        }

        [HttpPost]
        public IActionResult CreateNewTrophy()
        {
            //Console.WriteLine("SignIn", signIn.UserName, signIn.Email, signIn.Password, signIn.PhoneNumber);
            //return View();

            //connectionString();
            //con.Open();
            //com.Connection = con;
            //com.CommandText = "INSERT INTO Admin (user_name, password, email, phone_number) VALUES ('" + signIn.UserName + "', '" + signIn.Password + "', '" + signIn.Email + "', '" + signIn.PhoneNumber + "') ";
            //dr = com.ExecuteReader();
            //con.Close();
            return View();
        }

        [HttpPost]
        public IActionResult CreateANewTrophy(Trophy trophy)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO Trophy (trophy_name, start_date, end_date, teams) VALUES ('" + trophy.Name + "', '" + trophy.StartDate + "', '" + trophy.EndDate + "', '" + trophy.Teams + "') ";
            dr = com.ExecuteReader();
            con.Close();
            return View("CreateTrophy");
        }

        public IActionResult EditTrophy()
        {
            return View();
        }

        public IActionResult DeleteTrophy()
        {
            return View();
        }

        public IActionResult PlayerRegistration()
        {

            var player = new List<Player>();

            String constr = "Data Source=DESKTOP-ES9JH7P;Initial Catalog=ESPORTS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                String sql = "SELECT * FROM Player WHERE status = 0";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Player p = new Player();
                            p.ID = reader.GetInt32(0);
                            p.FirstName = reader.GetString(1);
                            p.Email = reader.GetString(2);
                            p.BasePrice = reader.GetInt32(3).ToString();
                            p.Status = reader.GetInt32(4);
                            p.TrophyRegistered = reader.GetString(5);
                            //p.TrophyRegistered = reader.GetString(3);

                            player.Add(p);
                        }
                    }
                }
            }

            return View("PlayerRegistrationProcess", player);
        }

        public IActionResult EditPlayerBasePrice(int id, string FirstName)
        {
            return View();
        }

        public IActionResult SaveEditedPlayerBasePrice(Player player)
        {
            //Console.WriteLine(player);

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "UPDATE Player SET baseprice = '"+player.BasePrice+ "', status = 1 WHERE id = '" + player.ID+"' ";
            dr = com.ExecuteReader();
            con.Close();
            return View();
        }

        public IActionResult AuctionList()
        {
            var playerAuction = new List<PlayerAuction>();

            String constr = "Data Source=DESKTOP-ES9JH7P;Initial Catalog=ESPORTS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                String sql = "SELECT * FROM Auction";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PlayerAuction p = new PlayerAuction();
                            p.ID = reader.GetInt32(0);
                            p.AuctionName = reader.GetString(1);
                            p.StartDate = reader.GetDateTime(2).ToString();
                            p.EndDate = reader.GetDateTime(3).ToString();

                            playerAuction.Add(p);
                        }
                    }
                }
            }
            return View(playerAuction);
        }

        public IActionResult CreateAuction()
        {
            return View();
        }

        public IActionResult CreateNewAuction(PlayerAuction playerAuction)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO Auction (auctionName, startDate, endDate) VALUES ('" + playerAuction.AuctionName + "', '" + playerAuction.StartDate + "', '" + playerAuction.EndDate + "') ";
            dr = com.ExecuteReader();
            con.Close();

            //return View("AuctionList");
            return View();
        }

        public IActionResult AddPlayersToTeams(int id)
        {
            var playerAuction = new List<PlayerAuction>();

            String constr = "Data Source=DESKTOP-ES9JH7P;Initial Catalog=ESPORTS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                String sql = "SELECT * FROM Auction WHERE id = '"+id+"' ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PlayerAuction p = new PlayerAuction();
                            p.ID = reader.GetInt32(0);
                            p.AuctionName = reader.GetString(1);
                            p.StartDate = reader.GetDateTime(2).ToString();
                            p.EndDate = reader.GetDateTime(3).ToString();

                            playerAuction.Add(p);
                        }
                    }
                }
            }
            return View(playerAuction[0]);
            //return View();
        }

        public IActionResult SavePlayerBuy(SavePlayercs savePlayercs)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO Auctioned (AuctionName, PlayerName, SoldPrice, TeamBought) VALUES ('" + savePlayercs.AuctionName + "', '" + savePlayercs.PlayerName + "', '" + savePlayercs.SoldPrice + "', '" + savePlayercs.TeamBought + "') ";
            dr = com.ExecuteReader();
            con.Close();
            return View();
        }

        public IActionResult DeleteT(int id)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "DELETE FROM Trophy WHERE id = '"+id+"' ";
            dr = com.ExecuteReader();
            con.Close();
            return View();
        }

        public IActionResult TeamRegistration()
        {
            var team = new List<Team>();

            String constr = "Data Source=DESKTOP-ES9JH7P;Initial Catalog=ESPORTS;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                String sql = "SELECT * FROM Teams Where status = 0";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Team p = new Team();
                            p.ID = reader.GetInt32(0);
                            p.Name = reader.GetString(1);
                            p.MaxPrice = reader.GetInt32(2);

                            team.Add(p);
                        }
                    }
                }
            }
            return View(team);
        }

        public IActionResult EditTeamBasePrice(int id, string Name)
        {
            return View();
        }

        public IActionResult AddTeamBasePrice(Team team)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "UPDATE Teams SET maxPrice = '" + team.MaxPrice + "', status = 1 WHERE id = '" + team.ID + "' ";
            dr = com.ExecuteReader();
            con.Close();
            return View();
        }
    }
}
