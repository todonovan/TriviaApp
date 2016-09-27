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
        /*public static Session GetById(int id, SQLiteConnection dbConn)
        {
            string sql = $"SELECT * FROM Sessions WHERE id = {id};";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            SQLiteDataReader reader = command.ExecuteReader();

            // ExecuteReader() returns a reader object; we iterate through the data and use a factory to construct appropriate C# object.

            int year = (int)reader["year"];
            string = "";
            Session s = SessionFactory.BuildNewSession();
            return s;
        }*/

        public static Session CreateNewSession(SQLiteConnection dbConn)
        {
            // Build a blank Session object, insert a blank row into db.
            Session s = SessionFactory.BuildNewSession();
            DateTime currentDateTime = DateTime.Now;
            string sqlFormattedDate = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = $"INSERT INTO Sessions (created_at) VALUES ({sqlFormattedDate});";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            // Getting the id and date string of the newly entered Session row so our Session object has correct info.
            sql = $"SELECT MAX(id) FROM Sessions";
            command = new SQLiteCommand(sql, dbConn);
            SQLiteDataReader reader = command.ExecuteReader();
            int id = (int)reader["id"];
            s.Id = id;
            string date = (string)reader["created_at"];
            s.CreatedAt = DateTime.Parse(date);
            command.Dispose();

            return s;
        }

        /// <summary>
        /// Update a previously created Session in the database.
        /// </summary>
        /// <param name="session">Object to be updated.</param>
        /// <returns></returns>
        public static void UpdateSession(Session session, SQLiteConnection dbConn)
        {
            int id = session.Id;
            int year = session.Year;

            string team_id_list = string.Empty;
            string round_id_list = string.Empty;
            string score_id_list = string.Empty;
            foreach (var t in session.TeamList)
            {
                team_id_list += t.Id.ToString();
                team_id_list += ",";
            }
            foreach (var r in session.RoundList)
            {
                round_id_list += r.Id.ToString();
                round_id_list += ",";
            }
            foreach (var sc in session.ScoreList)
            {
                score_id_list += sc.Id.ToString();
                score_id_list += ",";
            }
            string sql = $"UPDATE Sessions SET ";
            sql += $"year={year},";
            sql += $"team_id_list={team_id_list}";
            sql += $"round_id_list={round_id_list}";
            sql += $"score_id_list={score_id_list}";
            sql += $"WHERE id={id};";
            SQLiteCommand command = new SQLiteCommand(sql, dbConn);
            command.ExecuteNonQuery();

            command.Dispose();
        }
    }
}
