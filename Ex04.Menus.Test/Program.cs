using Ex04.Menus.Interfaces;
using Ex04.Menus.Delegates;
using System;


namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            runInterfaceImplementaion();
            runDelegateImplementaion();
        }

        private static void runDelegateImplementaion()
        {
            //Menu Item 1
            Delegates.SubMenuItem actionsAndInfo = new Delegates.SubMenuItem("Actions and Info");

            //Menu Item 1.1
            FunctionMenuItem displayVersion = new FunctionMenuItem("Display Version");
            displayVersion.m_ExecuteFunction += DisplayVersion.Display;
            actionsAndInfo.AddMenuItem(displayVersion);

            //Menu Item 1.2
            Delegates.SubMenuItem actions = new Delegates.SubMenuItem("Actions");

            //Menu Item 1.2.1
            FunctionMenuItem spaceCounter = new FunctionMenuItem("Count Spaces");
            spaceCounter.m_ExecuteFunction += SpaceCounter.Count;
            actions.AddMenuItem(spaceCounter);

            //Menu Item 1.2.2
            FunctionMenuItem charsCounter = new FunctionMenuItem("Chars Count");
            charsCounter.m_ExecuteFunction += CharsCounter.Count;
            actions.AddMenuItem(charsCounter);
            actionsAndInfo.AddMenuItem(actions);

            //Menu Item 2
            Delegates.SubMenuItem dateAndTime = new Delegates.SubMenuItem("Show Date/Time");

            //Menu Item 2.1
            FunctionMenuItem showTime = new FunctionMenuItem("Show Time");
            showTime.m_ExecuteFunction += DisplayTime.Display;
            dateAndTime.AddMenuItem(showTime);

            //Menu Item 2.2
            FunctionMenuItem showDate = new FunctionMenuItem("Show Date");
            showDate.m_ExecuteFunction += DisplayDate.Display;
            dateAndTime.AddMenuItem(showDate);

            /* Prepare main menu */
            Delegates.SubMenuItem mainMenu = new Delegates.SubMenuItem("Main Menu - Delegates Implemented");
            mainMenu.AddMenuItem(actionsAndInfo);
            mainMenu.AddMenuItem(dateAndTime);
            Delegates.MainMenu interfaceMainMenu = new Delegates.MainMenu(mainMenu);

            /* execute */
            interfaceMainMenu.Show();
        }

        private static void runInterfaceImplementaion()
        {
            /* Prepare all menus */

            //Menu Item 1
            Interfaces.SubMenuItem actionsAndInfo = new Interfaces.SubMenuItem("Actions and Info");

            //Menu Item 1.1
            IExecuteFlowLogic displayVersion = new DisplayVersion();
            actionsAndInfo.AddMenuItem(new ExecuteFlowMenueItem("Display Version", displayVersion));

            //Menu Item 1.2
            Interfaces.SubMenuItem actions = new Interfaces.SubMenuItem("Actions");

            //Menu Item 1.2.1
            IExecuteFlowLogic spaceCounter = new SpaceCounter();
            actions.AddMenuItem(new ExecuteFlowMenueItem("Count Spaces", spaceCounter));

            //Menu Item 1.2.2
            IExecuteFlowLogic charsCounter = new CharsCounter();
            actions.AddMenuItem(new ExecuteFlowMenueItem("Chars Count", charsCounter));
            actionsAndInfo.AddMenuItem(actions);

            //Menu Item 2
            Interfaces.SubMenuItem dateAndTime = new Interfaces.SubMenuItem("Show Date/Time");

            //Menu Item 2.1
            IExecuteFlowLogic showTime = new DisplayTime();
            dateAndTime.AddMenuItem(new ExecuteFlowMenueItem("Show Time", showTime));

            //Menu Item 2.2
            IExecuteFlowLogic showDate = new DisplayDate();
            dateAndTime.AddMenuItem(new ExecuteFlowMenueItem("Show Date", showDate));

            /* Prepare main menu */
            Interfaces.SubMenuItem mainMenu = new Interfaces.SubMenuItem("Main Menu - Interface Implemented");
            mainMenu.AddMenuItem(actionsAndInfo);
            mainMenu.AddMenuItem(dateAndTime);
            Interfaces.MainMenu interfaceMainMenu = new Interfaces.MainMenu(mainMenu);

            /* execute */
            interfaceMainMenu.Show();

        }

        internal class DisplayVersion : IExecuteFlowLogic
        {
            public static void Display()
            {
                Console.WriteLine("Version: 17.2.4.0");
            }

            public void ExecuteFlowLogic()
            {
                Display();
            }
        }

        internal class SpaceCounter : IExecuteFlowLogic
        {
            public static void Count()
            {
                int numOfSpaces = 0;
                string UserInput;

                Console.WriteLine("Please type a sentence and press enter");
                UserInput = Console.ReadLine();

                foreach (char c in UserInput)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        numOfSpaces++;
                    }
                }

                Console.WriteLine("There are {0} spaces in you sentence", numOfSpaces);
            }

            public void ExecuteFlowLogic()
            {
                Count();
            }
        }

        internal class CharsCounter : IExecuteFlowLogic
        {
            public static void Count()
            {
                int numOfChars = 0;
                string UserInput;

                Console.WriteLine("Please type a sentence and press enter");
                UserInput = Console.ReadLine();

                foreach (char c in UserInput)
                {
                    if (char.IsLetter(c))
                    {
                        numOfChars++;
                    }
                }

                Console.WriteLine("There are {0} charecters in you sentence", numOfChars);
            }

            public void ExecuteFlowLogic()
            {
                Count();
            }
        }

        internal class DisplayTime : IExecuteFlowLogic
        {
            public static void Display()
            {
                Console.WriteLine("The time is {0}", DateTime.Now.ToString("H:mm:ss"));
            }

            public void ExecuteFlowLogic()
            {
                Display();
            }
        }

        internal class DisplayDate : IExecuteFlowLogic
        {
            public static void Display()
            {
                Console.WriteLine("The date right now is {0}", DateTime.Now.ToString("dd/MM/yyyy"));
            }

            public void ExecuteFlowLogic()
            {
                Display();
            }
        }

    }
}