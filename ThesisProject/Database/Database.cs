﻿using Npgsql;

namespace ThesisProject.Database
{
    public class Database
    {
        public static NpgsqlConnection Connection()
        {
            return new NpgsqlConnection("SERVER=localhost;Port=5432;Database=Musification;User Id=postgres;Password=123;");
        }

        public static NpgsqlDataReader ExecuteQuery(string query, NpgsqlConnection con)
        {
            NpgsqlConnection npgsqlConnection = con;
            NpgsqlCommand cmd = npgsqlConnection.CreateCommand();
            npgsqlConnection.Open();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            NpgsqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
