using System.Collections.ObjectModel;

namespace FlowTask_WinForms_Frontend
{
    /// <summary>
    /// Collections of observable elements to be used by the GUI
    /// </summary>
    public static class ObservableCollections
    {
        private static ObservableCollection<SelectableTaskDecorator> task_singleton;


        /// <summary>
        /// Observable task collection for use in the data grid (single instance)
        /// </summary>
        public static ObservableCollection<SelectableTaskDecorator> ObservableTaskCollection
        {
            get
            {
                return task_singleton ?? (task_singleton = new ObservableCollection<SelectableTaskDecorator>());
            }
        }

        /// <summary>
        /// Obersable collection generator for node view
        /// </summary>
        public static ObservableCollection<NodeDecorator> ObservableNodeCollection
        {
            get
            {
                return new ObservableCollection<NodeDecorator>();
            }
        }

    }

}
