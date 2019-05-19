using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Boreass.Models.DbModels;

namespace Boreass.Models
{
    public class BoreassContext
    {
        public string ConnectionString { get; set; }

        public BoreassContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Areas> GetAllAreas()
        {
            List<Areas> list = new List<Areas>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM areas", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Areas()
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Longitude = reader.GetString("longitude"),
                            Langitude = reader.GetString("langitude"),
                        });
                    }
                }
            }

            return list;
        }

        public List<Tribunes> GetAllTribunes()
        {
            List<Tribunes> list = new List<Tribunes>();

            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tribunes WHERE area_id='1'", conn);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Tribunes()
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Brand = reader.GetString("brand"),
                            Type = reader.GetString("type"),
                            Altitude = reader.GetDouble("altitude"),
                            Potential = reader.GetDouble("potential"),
                        });
                    }
                }
            }
            return list;
        }

        public List<Login> GetLoginInfo()
        {
            List<Login> list = new List<Login>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM login", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Login()
                        {
                            Id = reader.GetInt32("id"),
                            Username = reader.GetString("username"),
                            Password = reader.GetString("password"),
                        });
                    }
                }
            }
            return list;
        }
    }
}