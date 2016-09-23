using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DatabaseManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SQLiteConnection m_dbConnection;

            if (args[0] == "new")
            {
                m_dbConnection = StartNewDatabaseFile();
            }
            else
            {
                m_dbConnection = new SQLiteConnection("Data Source=trivia.sqlite;Version=3");
            }
            m_dbConnection.Open();
            Console.WriteLine("Command? nt for new table, end for end");
            string input = Console.ReadLine().ToLower();
            while (input != "end")
            {
                if (input == "nt")
                {
                    CreateTable(m_dbConnection);
                }
                Console.WriteLine("Next?");
                input = Console.ReadLine().ToLower();
            }
            m_dbConnection.Close();
        }

        private static SQLiteConnection StartNewDatabaseFile()
        {
            SQLiteConnection.CreateFile("trivia.sqlite");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=trivia.sqlite;Version=3");
            return m_dbConnection;
        }

        private static void CreateTable(SQLiteConnection dbConn)
        {
            Console.WriteLine("Provide table name: ");
            string name = Console.ReadLine();
            Console.WriteLine("How many columns?");
            int numCols = int.Parse(Console.ReadLine());
            string[] colNames = new string[numCols];
            string[] varTypes = new string[numCols];
            for (int i = 0; i < numCols; i++)
            {
                Console.WriteLine($"Name of column {i + 1}: ");
                colNames[i] = Console.ReadLine();
                Console.WriteLine($"Variable string of column {colNames[i]}: ");
                varTypes[i] = Console.ReadLine();
            }
            string sql = $"CREATE TABLE {name} (";
            for (int j = 0; j < numCols; j++)
            {
                sql += $"{colNames[j]} {varTypes[j]}, ";
            }
            sql = sql.Substring(0, sql.Length - 2);
            sql += ")";
            Console.WriteLine("Your SQL command string is as follows: ");
            Console.WriteLine(sql);
            Console.WriteLine("Is this correct? Y to execute command, N for incorrect.");
            string input = Console.ReadLine().ToLower();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Sorry, command not understood.");
                input = Console.ReadLine().ToLower();
            }

            if (input.ToLower() == "y")
            {
                SQLiteCommand command = new SQLiteCommand(sql, dbConn);
                command.ExecuteNonQuery();
            }
            else if (input.ToLower() == "n")
            {
                CreateTable(dbConn);
            }
        }

    }
}
