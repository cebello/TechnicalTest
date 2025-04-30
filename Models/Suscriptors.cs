using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TechnicalTest.ViewModels;

namespace TechnicalTest.Models
{
    public class Suscriptors: Localhost
    {

        public List<Suscriptor> list()
        {
            List<Suscriptor> list = new ();
            string query = "SELECT Id, Nombre FROM suscriptors";
            SqlCommand cmd = new (query, conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Suscriptor suscriptor = new()
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                };
                list.Add(suscriptor);
            }
            reader.Close();
            return list;
        }
        public Suscriptor find(int id)
        {
            Suscriptor suscriptor = null;
            string query = "SELECT Id, Nombre FROM suscriptors WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                suscriptor = new Suscriptor
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1)
                };
            }
            reader.Close();
            return suscriptor;
        }
        public bool isExist(string nombre)
        {
            string query = "SELECT COUNT(*) FROM suscriptors WHERE LOWER(Nombre) = LOWER(@nombre)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        public void add(string nombre)
        {
            string query = "INSERT INTO suscriptors (Nombre) VALUES (@nombre)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.ExecuteNonQuery();
        }

        public void delete(int id)
        {
            string query = "DELETE FROM suscriptors WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

    }
}
