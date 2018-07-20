using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public Stylist(string name, string details, int id = 0)
        {
            this.Id = id;
            this.Name = name;
            this.Details = details;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist)otherStylist;
                bool nameEquality = (this.Name == newStylist.Name);
                bool detailsEquality = (this.Details == newStylist.Details);
                return (nameEquality && detailsEquality);
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists; DELETE FROM stylists_specialties;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                string stylistDetails = rdr.GetString(2);
                Stylist newStylist = new Stylist(stylistName, stylistDetails, stylistId);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name, details) VALUES (@StylistName, @StylistDetails);";

            cmd.Parameters.AddWithValue("@StylistName", this.Name);
            cmd.Parameters.AddWithValue("@StylistDetails", this.Details);

            cmd.ExecuteNonQuery();
            this.Id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `stylists` WHERE id = @thisId;";

            cmd.Parameters.AddWithValue("@thisId", id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int stylistId = 0;
            string stylistName = "";
            string stylistDetails = "";

            while (rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
                stylistDetails = rdr.GetString(2);
            }

            Stylist foundItem = new Stylist(stylistName, stylistDetails, stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundItem;
        }

        public List<Client> GetClients()
        {
            List<Client> allClients = new List<Client> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = " + this.Id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int stylistId = rdr.GetInt32(2);

                Client newClient = new Client(name, stylistId);
                newClient.Id = id;
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public static void DeleteSingleStylist(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = " + id + "; DELETE FROM stylists_specialties WHERE stylist_id = " + id + ";";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void addSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";

            cmd.Parameters.AddWithValue("@StylistId", Id);
            cmd.Parameters.AddWithValue("@SpecialtyId", newSpecialty.Id);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Specialty> GetSpecialties()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialty_id FROM stylists_specialties WHERE stylist_id = @StylistId;";

            cmd.Parameters.AddWithValue("@StylistId", Id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            List<int> specialtyIds = new List<int> { };
            while (rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                specialtyIds.Add(specialtyId);
            }
            rdr.Dispose();

            List<Specialty> specialties = new List<Specialty> { };
            foreach (int specialtyId in specialtyIds)
            {
                var specialtyQuery = conn.CreateCommand() as MySqlCommand;
                specialtyQuery.CommandText = @"SELECT * FROM specialties WHERE id = @SpecialtyId;";

                cmd.Parameters.AddWithValue("@SpecialtyId", Id);

                var specialtyQueryRdr = specialtyQuery.ExecuteReader() as MySqlDataReader;
                while (specialtyQueryRdr.Read())
                {
                    int thisSpecialtyId = specialtyQueryRdr.GetInt32(0);
                    string specialtyName = specialtyQueryRdr.GetString(1);
                    Specialty foundSpecialty = new Specialty(specialtyName, thisSpecialtyId);
                    specialties.Add(foundSpecialty);
                }
                specialtyQueryRdr.Dispose();
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return specialties;
        }

    }
}
