using System;

namespace Ex04.Menus.Delegates
{

    public abstract class MenuItem
    {
        public event Action<MenuItem> ReportClickedMenuItem;

        private string m_Title;

        public string Title { get => m_Title;}

        private SubMenuItem fatherSubMenuItem;

        internal SubMenuItem FatherSubMenuItem { get => fatherSubMenuItem; set => fatherSubMenuItem = value; }

        public MenuItem(string i_Title)
        {
            this.m_Title = i_Title;
        }

        public void OnClickedMenuItem()
        {
            if (ReportClickedMenuItem != null)
            {
                ReportClickedMenuItem.Invoke(this);
            }
        }
    }
}
