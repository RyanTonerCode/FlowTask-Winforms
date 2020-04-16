using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using FlowTask_Backend;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.Input;

namespace FlowTask_WinForms_Frontent
{
    public partial class MainPage : Form
    {

        public MainPage()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;

            sfCalendarOverview.DrawCell += SfCalendarDrawCell;
            sfCalendarOverview.SelectionChanged += SfCalendarOverview_SelectionChanged;

            sfDataGrid.DataSource = ObservableCollections.ObservableTaskCollection;

            sfDataGrid.Columns.Add(new GridCheckBoxColumn { MappingName = "Selected", HeaderText = "", AllowCheckBoxOnHeader = true, AllowFiltering = false, CheckBoxSize = new Size(14, 14) });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "AssignmentName", HeaderText = "Assignment Name", MinimumWidth = 200 });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Category", HeaderText = "Category (Subject)", MinimumWidth = 200 });
            sfDataGrid.Columns.Add(new GridDateTimeColumn() { MappingName = "SubmissionDate", HeaderText = "Due Date" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "RemainingFlowSteps", HeaderText = "Remaining Nodes", AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill });

            sfDataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.None;
            sfDataGrid.QueryCellStyle += SfDataGrid_QueryCellStyle;
            sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            sfDataGrid.RowHeight = 40;

            Disposed += MainPage_Disposed;
        }

        private void MainPage_Disposed(object sender, EventArgs e)
        {
            Mediator.Logout();
        }

        private void drawDue(DateTime here)
        {
            Font f = new Font("Segoe UI Semibold", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Font f2 = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);

            flowLayout.FlowDirection = FlowDirection.TopDown;

            flowLayout.ForeColor = Color.White;
            flowLayout.BackColor = Color.White;

            flowLayout.Controls.Clear();
            Label header = new Label()
            {
                Font = f,
                Text = string.Format("Tasks due on {0}", here.ToString("dddd, dd MMMM yyyy")),
                Padding = new Padding(4, 4, 4, 4),
                Margin = new Padding(0),
                Height = 40,
                Width = flowLayout.Width,
                ForeColor = Color.Black,
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
            };

            flowLayout.Controls.Add(header);

            int number = 0;
            foreach (var task in ObservableCollections.ObservableTaskCollection)
                if (here.Day == task.SubmissionDate.Day && here.Month == task.SubmissionDate.Month && here.Year == task.SubmissionDate.Year)
                {
                    Label info = new Label()
                    {
                        Font = f2,
                        Text = string.Format("{0}. {1} ({2})", ++number, task.AssignmentName, task.Category),
                        Margin = new Padding(0),
                        Padding = new Padding(15, 4, 4, 4),
                        Height = 35,
                        BackColor = Color.White,
                        ForeColor = task.DrawColor,
                        Width = flowLayout.Width,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    info.Click += (object sender, EventArgs e) => Mediator.ShowViewTask(task);

                    flowLayout.Controls.Add(info);
                }
        }

        private void SfCalendarOverview_SelectionChanged(SfCalendar sender, Syncfusion.WinForms.Input.Events.SelectionChangedEventArgs e)
        {
            drawDue(sender.SelectedDate.Value);
        }

        private void SfDataGrid_QueryCellStyle(object sender, QueryCellStyleEventArgs e)
        {
            int index = e.RowIndex - 1;

            if (index == -1)
                return;

            e.Style.TextMargins = new Padding(3, 3, 3, 3);

            e.Style.Font = new Syncfusion.WinForms.DataGrid.Styles.GridFontInfo(new Font("Segoe UI", 13, FontStyle.Regular, GraphicsUnit.Point));

            var color = ObservableCollections.ObservableTaskCollection[index].DrawColor;
            if (e.Column.MappingName != "Selected")
            {
                e.Style.BackColor = color;
            }
        }

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
            lblWelcome.Text = "Welcome to FlowTask " + Mediator.Me.Username + "!";

            ObservableCollections.ObservableTaskCollection.CollectionChanged += ObservableTaskCollection_CollectionChanged;

            foreach(Task t in Mediator.Me.Tasks)
                ObservableCollections.ObservableTaskCollection.Add(new SelectableTaskDecorator(t));

            drawDue(DateTime.Today);
        }

        private void ObservableTaskCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(ObservableCollections.ObservableTaskCollection.Count == 0)
                lblTasks.Text = "Congrats, you have no tasks left!";
            else
                lblTasks.Text = string.Format("You have {0} task{1}!", ObservableCollections.ObservableTaskCollection.Count, (ObservableCollections.ObservableTaskCollection.Count == 1 ? "" : "s"));

            drawDue(sfCalendarOverview.SelectedDate.Value);
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            Mediator.ShowTaskCreate();
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {
            var Selected = ObservableCollections.ObservableTaskCollection.Where(x => x.Selected);
            if (Selected.Count() == 0) {
                MessageBox.Show("Please select a task first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var to_remove = new List<SelectableTaskDecorator>();

            foreach(SelectableTaskDecorator task in Selected)
            {
                if (task.Selected)
                {
                    DialogResult dr = MessageBox.Show(string.Format("Are you sure you want to delete your task ({0})?", task.AssignmentName), "Please confirm!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        //TaskCollection.ObservableTaskCollection.Remove(task);
                        DatabaseController.dbController.DeleteTask(task, Mediator.ac);

                        to_remove.Add(task);
                    }
                }
            }

            foreach(var task in to_remove)
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
            if(Selected.Count() == 0)
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
