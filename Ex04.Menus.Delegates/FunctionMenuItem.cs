using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public delegate void ExecuteFunction();

    public class FunctionMenuItem : MenuItem
    {
        public event ExecuteFunction m_ExecuteFunction; 
        public FunctionMenuItem(string i_Title) : base(i_Title){}

        public void OnExecuteFunction()
        {
            if (m_ExecuteFunction != null)
            {
                m_ExecuteFunction.Invoke();
            }
        }

    }
}
