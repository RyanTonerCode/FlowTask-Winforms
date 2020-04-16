using System.Collections.ObjectModel;

namespace FlowTask_WinForms_Frontent
{
    public static class ObservableCollections
    {
        private static ObservableCollection<SelectableTaskDecorator> task_singleton;


        public static ObservableCollection<SelectableTaskDecorator> ObservableTaskCollection
        {
            get
            {
                return task_singleton ?? (task_singleton = new ObservableCollection<SelectableTaskDecorator>());
            }
        }

        public static ObservableCollection<NodeDecorator> ObservableNodeCollection
        {
            get
            {
                return new ObservableCollection<NodeDecorator>();
            }
        }

    }

}
