namespace Ex04.Menus.Interfaces
{
    public interface IExecuteFlowLogic
    {
        void ExecuteFlowLogic();
    }

    public class ExecuteFlowMenueItem : MenuItem
    {
        private IExecuteFlowLogic m_FlowLogic;

        public ExecuteFlowMenueItem(string i_Title, IExecuteFlowLogic i_FlowLogicToExecute) :
            base(i_Title)
        {
            m_FlowLogic = i_FlowLogicToExecute;
        }

        public IExecuteFlowLogic FlowLogic
        {
            get => m_FlowLogic;
            set => m_FlowLogic = value;
        }
    }
}
