using FlowTask_Backend;
using System.Collections.ObjectModel;

namespace FlowTask_WinForms_Frontent
{
    public class TaskCollection
    {
        public TaskCollection()
        {
            TaskDetails = new ObservableCollection<SelectableTaskDecorator>();
        }

        public ObservableCollection<SelectableTaskDecorator> TaskDetails { get; set; }
    }

}
