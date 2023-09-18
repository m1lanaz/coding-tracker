using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_tracker
{
    internal class Menu
    {
        internal void showMenu()
        {
            UserSelection userSelection = new();
            var isSelected = false;
            do
            {
                Console.WriteLine("Hi! Welcome to your coding tracker!");
                Console.WriteLine($@"Please select what you wish to do today: 
t - Track more hours
v - View your hours
e - Exit the application");

                var optionSelected = Console.ReadLine();

                switch (optionSelected.ToUpper().Trim())
                {
                    case "T":
                        isSelected = true;
                        userSelection.AddTracker();
                        break;
                    case "V":
                        isSelected = true;
                        userSelection.ViewTrackers();
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please pick a valid letter");
                        break;
                }
            } while (!isSelected);
        }

        internal void backMenu()
        {

            var selected = false;
            do
            {
                Console.WriteLine($@"Would you like to go back to main menu? Please select one of the options:
m - Back to menu
e - Exit application");

                var optionSelected = Console.ReadLine();

                switch (optionSelected.ToUpper().Trim())
                {
                    case "M":
                        Console.WriteLine("You've picked M");
                        selected = true;
                        break;
                    case "E":
                        Console.WriteLine("You've picked E");
                        selected = true;
                        break;
                    default:
                        Console.WriteLine("Please pick a valid letter");
                        break;
                }

            } while (!selected);
        }
    }
}
