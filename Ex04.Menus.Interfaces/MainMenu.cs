using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuChoiceObserver
    {
        void ReportMenuChoice(MenuItem i_MenueItem);
    }

    public class MainMenu : IMenuChoiceObserver
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
                    m_CurrentActiveMenu = m_CurrentActiveMenu.FatherMenuItem;
                }
            }
            else
            {
                m_CurrentActiveMenu.MenuItemsList[i_UserChoice - 1].NotifyChoice();
            }
        }

        private void InitSubMenuHierarchy(MenuItem i_MenuItem)
        {
            i_MenuItem.MenueChoiceObserverList.Add(this);
            if (i_MenuItem is SubMenuItem)
            {
                foreach (MenuItem menuItem in (i_MenuItem as SubMenuItem).MenuItemsList)
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
                (i_MenueItem as ExecuteFlowMenueItem).FlowLogic.ExecuteFlowLogic();
                m_CurrentActiveMenu = m_MainMenu;
                UI.WaitForUserSignalToContinue();
            }
        }
    }
}
