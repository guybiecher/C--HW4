using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class SubMenuItem : MenuItem
    {
        private List<MenuItem> m_MenuItemsList;

        public SubMenuItem(string i_Title) :
            base(i_Title)
        {
            m_MenuItemsList = new List<MenuItem>();
        }

        public List<MenuItem> MenuItemsList
        {
            get => m_MenuItemsList;
            set => m_MenuItemsList = value;
        }
    }
}