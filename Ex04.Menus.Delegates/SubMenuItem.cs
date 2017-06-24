using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class SubMenuItem : MenuItem
    {
        private List<MenuItem> m_MenuItemList;
        public List<MenuItem> MenuItemList { get => m_MenuItemList; set => m_MenuItemList = value; }

        public SubMenuItem(string i_Title) : base(i_Title)
        {
            m_MenuItemList = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            i_MenuItem.FatherSubMenuItem = this;
            m_MenuItemList.Add(i_MenuItem);
        }
    }
}
