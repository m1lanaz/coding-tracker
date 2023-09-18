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
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("dd MMMM yyyy");
            Console.WriteLine($"You have coded ____ hours today ({formattedDate})");
        }

        internal void ViewTrackers() 
        {

        }
    }
}
