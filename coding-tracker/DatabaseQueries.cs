﻿using ConsoleTables;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_tracker
{
    internal class DatabaseQueries
    {
        internal static void CreateDatabaseAndTable()
        {
            string dbFilePath = @"C:\Users\Milana\Documents\Github\coding-tracker\coding-tracker\trackerDatabase.db";

            if (!File.Exists(dbFilePath))
            {
                using (SqliteConnection conn = new SqliteConnection($"Data Source={dbFilePath}"))
                {
                    conn.Open();

                    using (SqliteCommand createTableCommand = conn.CreateCommand())
                    {
                        createTableCommand.CommandText = @"
                            CREATE TABLE IF NOT EXISTS codeTracked (
                                dateTracked TEXT,
                                timeStarted TEXT,
                                timeFinished TEXT,
                                duration TEXT
                            )";
                        createTableCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        internal static void InsertValuesIntoTable(string date, string timeStarted, string timeFinished, string duration)
        {
            string dbFilePath = @"C:\Users\Milana\Documents\Github\coding-tracker\coding-tracker\trackerDatabase.db";

            using (SqliteConnection conn = new SqliteConnection($"Data Source={dbFilePath}"))
            {
                conn.Open();

                using (SqliteCommand insertCommand = conn.CreateCommand())
                {
                    insertCommand.CommandText = @"
                        INSERT INTO codeTracked (dateTracked, timeStarted, timeFinished, duration)
                        VALUES (@date, @timeStarted, @timeFinished, @duration)";

                    insertCommand.Parameters.AddWithValue("@date", date);
                    insertCommand.Parameters.AddWithValue("@timeStarted", timeStarted);
                    insertCommand.Parameters.AddWithValue("@timeFinished", timeFinished);
                    insertCommand.Parameters.AddWithValue("@duration", duration);

                    // Execute the INSERT statement
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                }
            }
        }

        internal static void FetchValues()
        {
            string dbFilePath = @"C:\Users\Milana\Documents\Github\coding-tracker\coding-tracker\trackerDatabase.db";

            using (SqliteConnection conn = new SqliteConnection($"Data Source={dbFilePath}"))
            {
                conn.Open();

                using (SqliteCommand command = conn.CreateCommand())
                {

                    command.CommandText = "SELECT * FROM codeTracked";

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        var table = new ConsoleTable("Date", "Time Started", "Time Finished", "Duration");

                        while (reader.Read())
                        {

                            string dateTracked = reader.GetString(0);
                            string timeStarted = reader.GetString(1);
                            string timeFinished = reader.GetString(2);
                            string duration = reader.GetString(3);

                            table.AddRow(dateTracked, timeStarted, timeFinished, duration);

                        }
                        table.Write();
                    }
                }
                conn.Close();
            }
        }
    }
}