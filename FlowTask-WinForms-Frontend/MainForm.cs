using FlowTask_Backend;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontend
{
    /// <summary>
    /// The main form/ home page for the user to see their task overview/ task list
    /// </summary>
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;

            //specialized drawing method to show what dates have tasks
            sfTaskCalendar.DrawCell += sfCalendarDrawCell;
            //specialized selection method to update UI to show tasks on that date
            sfTaskCalendar.SelectionChanged += sfCalendarOverview_SelectionChanged;

            //set the data binding
            sfTaskDataGrid.DataSource = ObservableCollections.ObservableTaskCollection;
            sfTaskDataGrid.LiveDataUpdateMode = Syncfusion.Data.LiveDataUpdateMode.AllowChildViewUpdate;

            //create columns for the data grid with the associated binding maps
            sfTaskDataGrid.Columns.Add(new GridCheckBoxColumn { MappingName = "Selected", HeaderText = "", AllowCheckBoxOnHeader = true, AllowFiltering = false, CheckBoxSize = new Size(18, 18) });
            sfTaskDataGrid.Columns.Add(new GridTextColumn() { MappingName = "AssignmentName", HeaderText = "Assignment Name", MinimumWidth = 200 });
            sfTaskDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Category", HeaderText = "Category (Subject)", MinimumWidth = 200 });
            sfTaskDataGrid.Columns.Add(new GridDateTimeColumn() { MappingName = "SubmissionDate", HeaderText = "Due Date", MinimumWidth = 150 });
            //set the last column to fill
            sfTaskDataGrid.Columns.Add(new GridTextColumn() { MappingName = "RemainingFlowSteps", HeaderText = "Remaining Nodes", AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill });

            //do not allow selection
            sfTaskDataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.None;
            //special painting of the rows
            sfTaskDataGrid.QueryCellStyle += sfDataGrid_QueryCellStyle;
            //fill the entire grid
            sfTaskDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            sfTaskDataGrid.RowHeight = 40;

            Disposed += mainPage_Disposed;
        }

        /// <summary>
        /// Tell the data grid to update (especially if an observable property changed)
        /// </summary>
        public void Redraw() { sfTaskDataGrid.Refresh(); }

        private void mainPage_Disposed(object sender, EventArgs e)
        {
            Mediator.Logout();
        }

        private static readonly Font taskHeadingFont = new Font("Segoe UI Semibold", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
        private static readonly Font taskLabelFont = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);

        /// <summary>
        /// Updates the task due flowLayoutPanel
        /// </summary>
        /// <param name="here"></param>
        private void drawTaskDue(DateTime here)
        {
            flwTaskLayout.FlowDirection = FlowDirection.TopDown;
            flwTaskLayout.ForeColor = Color.White;
            flwTaskLayout.BackColor = Color.White;

            flwTaskLayout.Controls.Clear();


            Label lblHeader = new Label()
            {
                Font = taskHeadingFont,
                Text = string.Format("Tasks due on {0}", here.ToString("dddd, dd MMMM yyyy")),
                Padding = new Padding(4, 4, 4, 4),
                Margin = new Padding(0),
                Height = 40,
                Width = flwTaskLayout.Width,
                ForeColor = Color.Black,
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
            };

            flwTaskLayout.Controls.Add(lblHeader);

            //show the tasks due on this day

            int taskNumber = 0;
            foreach (var task in getDrawListForDay(here))
            {
                Label lblInfo = new Label()
                {
                    Font = taskLabelFont,
                    Text = string.Format("{0}. {1} ({2})", ++taskNumber, task.AssignmentName, task.Category),
                    Margin = new Padding(0),
                    Padding = new Padding(15, 4, 4, 4),
                    Height = 36,
                    BackColor = Color.White,
                    ForeColor = task.DrawColor,
                    Width = flwTaskLayout.Width,
                    BorderStyle = BorderStyle.FixedSingle
                };

                lblInfo.Cursor = Cursors.Hand;

                //tool tip to inform user how to open task view
                var toolTip = new ToolTip
                {
                    ToolTipIcon = ToolTipIcon.Info,
                    IsBalloon = true,
                    ShowAlways = true
                };
                toolTip.SetToolTip(lblInfo, string.Format("Click to view task info for {0}", task.AssignmentName));

                lblInfo.Click += (object sender, EventArgs e) => Mediator.ShowViewTask(task);

                flwTaskLayout.Controls.Add(lblInfo);
            }
        }

        /// <summary>
        /// Retrieve the tasks due on the selected date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfCalendarOverview_SelectionChanged(SfCalendar sender, Syncfusion.WinForms.Input.Events.SelectionChangedEventArgs e)
        {
            drawTaskDue(sender.SelectedDate.Value);
        }

        /// <summary>
        /// Pretty print each row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfDataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {
            int index = e.RowIndex - 1;

            //do not paint the header
            if (index == -1)
                return;

            //custom cell style
            e.Style.TextMargins = new Padding(3, 3, 3, 3);
            e.Style.Font = new Syncfusion.WinForms.DataGrid.Styles.GridFontInfo(new Font("Segoe UI", 13, FontStyle.Regular, GraphicsUnit.Point));

            //check to make sure the row data is valid
            if (e.DataRow.RowData is SelectableTaskDecorator st)
            {
                //paint the background to the task color
                if (e.Column.MappingName != "Selected")
                    e.Style.BackColor = st.DrawColor;
            }
        }

        private List<SelectableTaskDecorator> getDrawListForDay(DateTime here)
        {
            return ObservableCollections.ObservableTaskCollection.Where(x => x.SubmissionDate.DayOfYear == here.DayOfYear && x.SubmissionDate.Year == here.Year).ToList(); 
        }

        /// <summary>
        /// Draw the mini task rectangles in the calendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void sfCalendarDrawCell(SfCalendar sender, Syncfusion.WinForms.Input.Events.DrawCellEventArgs args)
        {
            args.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //darken the trailing dates (not in the current month)
            if (args.IsTrailingDate)
                args.ForeColor = Color.DarkGray;

            int startPosition = 0;

            //ensure a date is selected
            if (!args.Value.HasValue)
                return;

            var drawList = getDrawListForDay(args.Value.Value);

            foreach (var task in drawList)
            {
                args.Handled = true;

                Color c = args.IsTrailingDate ? Color.DarkGray : Color.Black;

                TextRenderer.DrawText(args.Graphics, args.Value.Value.Day.ToString(), new Font("Segoe UI", 10, FontStyle.Regular), args.CellBounds, c, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                args.Graphics.FillRectangle(new SolidBrush(task.DrawColor), new Rectangle((args.CellBounds.X + (args.CellBounds.Width - args.CellBounds.Width / 2)) - (drawList.Count * 2) - (drawList.Count * 6) - startPosition, (args.CellBounds.Y + (args.CellBounds.Height - 20)), 13, 13));
                startPosition -= 18;
            }

        }

        private void mainPage_Load(object sender, EventArgs e)
        {
            //greeting
            lblWelcome.Text = string.Format("Welcome to FlowTask {0}!",Mediator.CurrentUser.Username);

            Text = string.Format("Connected to FlowTask as {0}", Mediator.CurrentUser.Username);

            //update count when task list is changed
            ObservableCollections.ObservableTaskCollection.CollectionChanged += observableTaskCollection_CollectionChanged;

            //generate selectable task decorators from the task list
            foreach (Task t in Mediator.CurrentUser.Tasks)
                ObservableCollections.ObservableTaskCollection.Add(new SelectableTaskDecorator(t));

            //show the tasks for the current day
            drawTaskDue(DateTime.Today);
        }

        private void observableTaskCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //show the number of tasks remaining
            var count = ObservableCollections.ObservableTaskCollection.Count;
            if (count == 0)
                lblTasks.Text = "Congrats, you have no tasks left!";
            else
                lblTasks.Text = string.Format("You have {0} task{1}!", count, Mediator.IsPlural(count));

            //show the tasks view for the updated task
            if(sfTaskCalendar.SelectedDate.HasValue)
                drawTaskDue(sfTaskCalendar.SelectedDate.Value);
        }

        /// <summary>
        /// Open the task creation page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            Mediator.ShowTaskCreation(sfTaskCalendar.SelectedDate);
        }

        /// <summary>
        /// Remove all selected tasks with confirmation dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteClick(object sender, EventArgs e)
        {
            var Selected = ObservableCollections.ObservableTaskCollection.Where(x => x.Selected);
            if (Selected.Count() == 0)
            {
                MessageBox.Show("Please select a task first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var to_remove = new List<SelectableTaskDecorator>(Selected.Count());

            foreach (SelectableTaskDecorator task in Selected)
            {
                DialogResult dr = MessageBox.Show(string.Format("Are you sure you want to delete your task ({0})?", task.AssignmentName), "Please confirm!", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    //TaskCollection.ObservableTaskCollection.Remove(task);
                    DatabaseController.GetDBController().DeleteTask(task, Mediator.AuthCookie);

                    to_remove.Add(task);
                }
            }

            //remove all confirmed tasks
            foreach (var task in to_remove)
                ObservableCollections.ObservableTaskCollection.Remove(task);

            to_remove.Clear();
        }

        /// <summary>
        /// Close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogoutClicked(object sender, EventArgs e)
        {
            Mediator.Logout();
        }

        /// <summary>
        /// Open all selected tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            var Selected = ObservableCollections.ObservableTaskCollection.Where(x => x.Selected);
            if (Selected.Count() == 0)
            {
                MessageBox.Show("Please select a task first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (SelectableTaskDecorator task in Selected)
                Mediator.ShowViewTask(task);
        }
    }
}
