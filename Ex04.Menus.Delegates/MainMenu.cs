using System;

namespace Ex04.Menus.Delegates
{

    public class MainMenu
    {
        private SubMenuItem m_MainMenu;
        private SubMenuItem m_CurrentActiveMenu;
        private bool m_IsMainMenu;
        private bool m_ExitProgramFlag;

        public MainMenu(SubMenuItem i_MainMenu)
        {
            m_MainMenu = i_MainMenu;
            m_CurrentActiveMenu = i_MainMenu;
            m_IsMainMenu = true;
            m_ExitProgramFlag = false;
        }

        public void Show()
        {
            int numOfOptionsInSubMenu;

            InitSubMenuHierarchy(m_MainMenu);
            while (!m_ExitProgramFlag)
            {
                Console.Clear();
                m_IsMainMenu = (m_CurrentActiveMenu == m_MainMenu);
                numOfOptionsInSubMenu = UI.ShowMenu(m_CurrentActiveMenu, m_IsMainMenu);
                ExecuteProgramNextStep(UI.GetUserInput(numOfOptionsInSubMenu, m_IsMainMenu));
            }
        }

        private void ExecuteProgramNextStep(int i_UserChoice)
        {
            if (i_UserChoice == 0)
            {
                if (m_IsMainMenu)
                {
                    m_ExitProgramFlag = true;
                }
                else
                {
                    m_CurrentActiveMenu = m_CurrentActiveMenu.FatherSubMenuItem;
                }
            }
            else
            {
                m_CurrentActiveMenu.MenuItemList[i_UserChoice - 1].OnClickedMenuItem();
            }
        }

        private void InitSubMenuHierarchy(MenuItem i_MenuItem)
        {
            i_MenuItem.ReportClickedMenuItem += ReportMenuChoice;
            if (i_MenuItem is SubMenuItem)
            {
                foreach (MenuItem menuItem in (i_MenuItem as SubMenuItem).MenuItemList)
                {
                    InitSubMenuHierarchy(menuItem);
                }
            }
        }

        public void ReportMenuChoice(MenuItem i_MenueItem)
        {
            Console.Clear();
            if (i_MenueItem is SubMenuItem)
            {
                m_CurrentActiveMenu = i_MenueItem as SubMenuItem;
            }
            else
            {
                (i_MenueItem as FunctionMenuItem).OnExecuteFunction();
                m_CurrentActiveMenu = m_CurrentActiveMenu.FatherSubMenuItem;
                UI.WaitForUserSignalToContinue();
            }
        }
    }
}
