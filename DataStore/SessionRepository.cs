using DataStore.Factories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class SessionRepository
    {
        public static Session GetById(int id, SQLiteConnection dbConn)
        {
            string sql = $"SELECT * FROM Sessions WHERE id = {id}";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            SQLiteDataReader reader = command.ExecuteReader();

            // ExecuteReader() returns a reader object; we iterate through the data and use a factory to construct appropriate C# object.

            int id = (int)reader["id"];
            int year = (int)reader["year"];
            int string = 
            Session s = SessionFactory.BuildNewSession(reader.);
            return s;
        }
    }
}
