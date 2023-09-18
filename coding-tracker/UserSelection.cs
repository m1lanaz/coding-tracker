using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_tracker
{
    internal class UserSelection
    {
        internal void AddTracker()
        {
            DatabaseQueries.CreateDatabaseAndTable();
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("dd MMMM yyyy");
            Console.WriteLine($"You have coded ____ hours today ({formattedDate})");
            DatabaseQueries.InsertValuesIntoTable("hi", "hello", "heya", "Mornign");
        }

        internal void ViewTrackers() 
        {
            var menu = new Menu();
            try
            {
                DatabaseQueries.FetchValues();
            }
            catch (Exception ex)
            {
                Console.WriteLine("You haven't tracked any hours!");
                Thread.Sleep(1500);
                menu.backMenu();
            }
        }
    }
}
