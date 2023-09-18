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

            using (SqliteConnection connection = new SqliteConnection($"Data Source={dbFilePath}"));


        }
    }
}
