using System;

namespace Ex04.Menus.Delegates
{
    public class UI
    {
        private const string k_Delimiter = "==============";
        private const string k_ExitTitle = "Exit Program";
        private const string k_BackTitle = "Go Back";

        public static int ShowMenu (SubMenuItem i_SubMenuItem, bool i_IsMainMenu)
        {
            int listIndex = 1;

            Console.WriteLine(i_SubMenuItem.Title);
            Console.WriteLine(k_Delimiter);

            foreach (MenuItem menuItem in i_SubMenuItem.MenuItemList)
            {
                Console.WriteLine("{0}. {1}", listIndex, menuItem.Title);
                listIndex++;
            }

            Console.WriteLine("0. {0}", i_IsMainMenu ? k_ExitTitle : k_BackTitle);

            return listIndex;
        }

        public static int GetUserInput(int i_NumOfOptionsInSubMenu, bool i_IsMainMenu)
        {
            int userChoice;

            Console.WriteLine("Please enter your choice (0-{0} or 0 to {1}):",
                i_NumOfOptionsInSubMenu,
                (i_IsMainMenu ? k_ExitTitle : k_BackTitle));
            string userInput = Console.ReadLine();
            bool isValidInput = int.TryParse(userInput, out userChoice);

            while (!ValidateUserInput(userInput, i_NumOfOptionsInSubMenu, out userChoice))
            {
                Console.WriteLine("Error, input should be a number between 0 and {0}, please try again", i_NumOfOptionsInSubMenu);
                userInput = Console.ReadLine();
            }

            return userChoice;
        }

        private static bool ValidateUserInput(string i_UserInput, int i_MaxValue, out int o_UserChoice)
        {
            bool isValid;
            bool isNumeric = int.TryParse(i_UserInput, out o_UserChoice);

            if (!isNumeric || o_UserChoice < 0 || o_UserChoice > i_MaxValue)
            {
                isValid = false;
            } else
            {
                isValid = true;
            }

            return isValid;
        }

        internal static void WaitForUserSignalToContinue()
        {
            Console.WriteLine("Job processed, thank you for your choice. Please press enter to continue");
            Console.ReadLine();
        }
    }
}
