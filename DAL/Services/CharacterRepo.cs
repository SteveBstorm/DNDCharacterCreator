using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CharacterRepo : ICharacterRepo
    {
        private string _connectionString;

        public CharacterRepo(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        private Character Converter(SqlDataReader reader)
        {
            return new Character
            {
                Id = (int)reader["Id"],
                Nom = reader["Nom"].ToString(),
                Race = reader["Race"].ToString(),
                Force = (int)reader["Force"],
                Endurance = (int)reader["Endurance"],
                PV = (int)reader["PV"]
            };
        }

        public int Create(Character c)
        {
            using(SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Personnage (Nom, Race, Force, Endurance, PV) " +
                        "OUTPUT INSERTED.Id VALUES (@nom, @race, @force, @endu, @pv)";

                    cmd.Parameters.AddWithValue("@nom", c.Nom);
                    cmd.Parameters.AddWithValue("@race", c.Race);
                    cmd.Parameters.AddWithValue("@force", c.Force);
                    cmd.Parameters.AddWithValue("@endu", c.Endurance);
                    cmd.Parameters.AddWithValue("@pv", c.PV);

                    cnx.Open();
                    int id = (int)cmd.ExecuteScalar();
                    cnx.Close();
                    return id;
                }
            }
        }

        public IEnumerable<Character> GetAll()
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Personnage";
                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Converter(reader);
                        }
                    }
                }
            }
        }

        public Character GetById(int id)
        {
            using (SqlConnection cnx = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = cnx.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Personnage WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cnx.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Converter(reader);
                        }
                    }
                }
            }
            throw new ArgumentNullException("Personnage inexistant");
        }
    }
}
