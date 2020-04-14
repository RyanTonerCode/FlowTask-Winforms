using System.Collections.ObjectModel;

namespace FlowTask_WinForms_Frontent
{
    public static class TaskCollection
    {
        private static ObservableCollection<SelectableTaskDecorator> singleton;


        public static ObservableCollection<SelectableTaskDecorator> ObservableTaskCollection { get {
                return singleton ?? (singleton = new ObservableCollection<SelectableTaskDecorator>());
            }
        }
    }

}
