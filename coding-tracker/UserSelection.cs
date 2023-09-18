using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_tracker
{
    internal class UserSelection
    {
        internal void AddTracker()
        {
            var menu = new Menu();

            Console.Clear();

            DatabaseQueries.CreateDatabaseAndTable();

            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("dd MMMM yyyy");

            Console.WriteLine($"We're going to be adding this time for todays date, {formattedDate} \n");
            Console.WriteLine("Enter in the time, using the 24 hour clock, you started coding");
            Console.WriteLine("Format HH:MM");
            var timeStartedCoding = Console.ReadLine();

            Console.WriteLine("\n Enter in the time, using the 24 hour clock, you finished coding");
            Console.WriteLine("Format HH:MM");
            var timeFinishedCoding = Console.ReadLine();

            // For calculation convert into date types:
            DateTime startedTimeConvert = DateTime.ParseExact(timeStartedCoding, "HH:mm", CultureInfo.InvariantCulture);

            DateTime finishedTimeConvert = DateTime.ParseExact(timeFinishedCoding, "HH:mm", CultureInfo.InvariantCulture);

            // For calculation: 
            var diffOfDates = finishedTimeConvert.Subtract(startedTimeConvert);
            var hourDifference = diffOfDates.Hours;
            var minuteDifference = diffOfDates.Minutes;

            Console.WriteLine($"You Programmed for {hourDifference} hours and {minuteDifference} minutes today!");

            DatabaseQueries.InsertValuesIntoTable(formattedDate, timeStartedCoding, timeFinishedCoding, $"{hourDifference} Hours {minuteDifference} Minutes");

            menu.backMenu();
        }

        internal void ViewTrackers() 
        {
            var menu = new Menu();
            try
            {
                DatabaseQueries.FetchValues();
                menu.backMenu();
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
