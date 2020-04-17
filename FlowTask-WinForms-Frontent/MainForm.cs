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

namespace FlowTask_WinForms_Frontent
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
            sfTaskCalendar.DrawCell += SfCalendarDrawCell;
            //specialized selection method to update UI to show tasks on that date
            sfTaskCalendar.SelectionChanged += SfCalendarOverview_SelectionChanged;

            //set the data binding
            sfDataGrid.DataSource = ObservableCollections.ObservableTaskCollection;
            sfDataGrid.LiveDataUpdateMode = Syncfusion.Data.LiveDataUpdateMode.AllowChildViewUpdate;

            //create columns for the data grid with the associated binding maps
            sfDataGrid.Columns.Add(new GridCheckBoxColumn { MappingName = "Selected", HeaderText = "", AllowCheckBoxOnHeader = true, AllowFiltering = false, CheckBoxSize = new Size(18, 18) });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "AssignmentName", HeaderText = "Assignment Name", MinimumWidth = 200 });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Category", HeaderText = "Category (Subject)", MinimumWidth = 200 });
            sfDataGrid.Columns.Add(new GridDateTimeColumn() { MappingName = "SubmissionDate", HeaderText = "Due Date", MinimumWidth = 150 });
            //set the last column to fill
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "RemainingFlowSteps", HeaderText = "Remaining Nodes", AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill });

            //do not allow selection
            sfDataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.None;
            //special painting of the rows
            sfDataGrid.QueryCellStyle += SfDataGrid_QueryCellStyle;
            //fill the entire grid
            sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            sfDataGrid.RowHeight = 40;

            Disposed += MainPage_Disposed;
        }

        /// <summary>
        /// Tell the data grid to update (especially if an observable property changed)
        /// </summary>
        public void Redraw() { sfDataGrid.Refresh(); }

        private void MainPage_Disposed(object sender, EventArgs e)
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
            foreach (var task in ObservableCollections.ObservableTaskCollection)
                if (here.Day == task.SubmissionDate.Day && here.Month == task.SubmissionDate.Month && here.Year == task.SubmissionDate.Year)
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
        private void SfCalendarOverview_SelectionChanged(SfCalendar sender, Syncfusion.WinForms.Input.Events.SelectionChangedEventArgs e)
        {
            drawTaskDue(sender.SelectedDate.Value);
        }

        private void SfDataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
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

        /// <summary>
        /// Draw the mini task rectangles in the calendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void SfCalendarDrawCell(SfCalendar sender, Syncfusion.WinForms.Input.Events.DrawCellEventArgs args)
        {
            args.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            List<SelectableTaskDecorator> to_draw = new List<SelectableTaskDecorator>();

            if (args.IsTrailingDate)
                args.ForeColor = Color.DarkGray;

            DateTime here = args.Value.Value;

            foreach (var task in ObservableCollections.ObservableTaskCollection)
                if (here.Day == task.SubmissionDate.Day && here.Month == task.SubmissionDate.Month && here.Year == task.SubmissionDate.Year)
                    to_draw.Add(task);

            int startPosition = 0;

            foreach (var task in to_draw)
            {
                args.Handled = true;

                Color c = args.IsTrailingDate ? Color.DarkGray : Color.Black;

                TextRenderer.DrawText(args.Graphics, args.Value.Value.Day.ToString(), new Font("Segoe UI", 10, FontStyle.Regular), args.CellBounds, c, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                args.Graphics.FillRectangle(new SolidBrush(task.DrawColor), new Rectangle((args.CellBounds.X + (args.CellBounds.Width - args.CellBounds.Width / 2)) - (to_draw.Count * 2) - (to_draw.Count * 6) - startPosition, (args.CellBounds.Y + (args.CellBounds.Height - 20)), 12, 12));
                startPosition -= 18;
            }

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome to FlowTask " + Mediator.CurrentUser.Username + "!";

            ObservableCollections.ObservableTaskCollection.CollectionChanged += ObservableTaskCollection_CollectionChanged;

            foreach (Task t in Mediator.CurrentUser.Tasks)
                ObservableCollections.ObservableTaskCollection.Add(new SelectableTaskDecorator(t));

            drawTaskDue(DateTime.Today);
        }

        private void ObservableTaskCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ObservableCollections.ObservableTaskCollection.Count == 0)
                lblTasks.Text = "Congrats, you have no tasks left!";
            else
                lblTasks.Text = string.Format("You have {0} task{1}!", ObservableCollections.ObservableTaskCollection.Count, (ObservableCollections.ObservableTaskCollection.Count == 1 ? "" : "s"));

            drawTaskDue(sfTaskCalendar.SelectedDate.Value);
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            Mediator.ShowTaskCreation(sfTaskCalendar.SelectedDate);
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {
            var Selected = ObservableCollections.ObservableTaskCollection.Where(x => x.Selected);
            if (Selected.Count() == 0)
            {
                MessageBox.Show("Please select a task first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var to_remove = new List<SelectableTaskDecorator>();

            foreach (SelectableTaskDecorator task in Selected)
            {
                if (task.Selected)
                {
                    DialogResult dr = MessageBox.Show(string.Format("Are you sure you want to delete your task ({0})?", task.AssignmentName), "Please confirm!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        //TaskCollection.ObservableTaskCollection.Remove(task);
                        DatabaseController.dbController.DeleteTask(task, Mediator.AuthCookie);

                        to_remove.Add(task);
                    }
                }
            }

            foreach (var task in to_remove)
                ObservableCollections.ObservableTaskCollection.Remove(task);

            to_remove.Clear();
        }

        private void btnLogoutClicked(object sender, EventArgs e)
        {
            Mediator.Logout();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var Selected = ObservableCollections.ObservableTaskCollection.Where(x => x.Selected);
            if (Selected.Count() == 0)
            {
                MessageBox.Show("Please select a task first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (SelectableTaskDecorator task in Selected)
                if (task.Selected)
                    Mediator.ShowViewTask(task);
        }
    }
}
