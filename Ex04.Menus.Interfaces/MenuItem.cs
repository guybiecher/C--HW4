using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private List<IMenuChoiceObserver> m_MenueChoiceObserverList;
        private string m_Title;
        private SubMenuItem m_FatherMenuItem;

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
            m_MenueChoiceObserverList = new List<IMenuChoiceObserver>();
        }

        public List<IMenuChoiceObserver> MenueChoiceObserverList
        {
            get => m_MenueChoiceObserverList;
            set => m_MenueChoiceObserverList = value;
        }
        public string Title
        {
            get => m_Title;
            set => m_Title = value;
        }
        public SubMenuItem FatherMenuItem
        {
            get => m_FatherMenuItem;
            set => m_FatherMenuItem = value;
        }

        public void NotifyChoice()
        {
            foreach (IMenuChoiceObserver observer in m_MenueChoiceObserverList)
            {
                observer.ReportMenuChoice(this);
            }
        }
    }
}
