using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FlowTask_Backend;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.Input;

namespace FlowTask_WinForms_Frontent
{
    public partial class MainPage : Form
    {

        public MainPage()
        {
            InitializeComponent();

            sfCalendarOverview.Style.BorderColor = ColorTranslator.FromHtml("#FFDFDFDF");
            sfCalendarOverview.Style.Cell.CellBackColor = ColorTranslator.FromHtml("#FF555555");
            sfCalendarOverview.Style.Cell.CellForeColor = ColorTranslator.FromHtml("#FFFFFFFF");
            sfCalendarOverview.Style.Cell.SelectedCellBorderColor = ColorTranslator.FromHtml("#0078d7");
            sfCalendarOverview.Style.Cell.SelectedCellBackColor = ColorTranslator.FromHtml("#FF0078D7");

            sfCalendarOverview.Style.Cell.SelectedCellForeColor = ColorTranslator.FromHtml("#FFFFFFFF");
            sfCalendarOverview.Style.Cell.TrailingCellBackColor = ColorTranslator.FromHtml("#FF555555");
            sfCalendarOverview.Style.Header.BackColor = ColorTranslator.FromHtml("#FF555555");
            sfCalendarOverview.Style.Header.ForeColor = ColorTranslator.FromHtml("#FFDFDFDF");
            sfCalendarOverview.Style.Header.HoverForeColor = ColorTranslator.FromHtml("#FFFFFFFF");
            sfCalendarOverview.Style.Header.DayNamesForeColor = ColorTranslator.FromHtml("#FFFFFFFF");
            sfCalendarOverview.Style.Header.DayNamesBackColor = ColorTranslator.FromHtml("#FF555555");

            sfCalendarOverview.Style.Header.NavigationButtonForeColor = ColorTranslator.FromHtml("#FFDFDFDF");
            sfCalendarOverview.Style.Header.NavigationButtonHoverForeColor = ColorTranslator.FromHtml("#FFFFFFFF");

            sfCalendarOverview.DrawCell += SfCalendarDrawCell;

            sfDataGrid.DataSource = TaskCollection.ObservableTaskCollection;

            sfDataGrid.Columns.Add(new GridCheckBoxColumn { MappingName = "Selected", HeaderText = "", AllowCheckBoxOnHeader = true, AllowFiltering = false, CheckBoxSize = new Size(14, 14) });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "AssignmentName", HeaderText = "Assignment Name" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Category", HeaderText = "Category (Subject)" });
            sfDataGrid.Columns.Add(new GridDateTimeColumn() { MappingName = "SubmissionDate", HeaderText = "Due Date" });

            sfDataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Multiple;

            sfDataGrid.SelectionController = new RowSelectionController(sfDataGrid);
        }

        void SfCalendarDrawCell(SfCalendar sender, Syncfusion.WinForms.Input.Events.DrawCellEventArgs args)
        {

            if (args.IsTrailingDate)
            {
                // Customize the cell appearance using options from DrawCellEventArgs
                args.ForeColor = Color.DarkGray;
            }
            else if (args.Value.Value == (new DateTime(2020, 4, 15, 0, 0, 0, 0)))
            {
                args.Handled = true;

                var font = new Font("Arial", 14, FontStyle.Regular);

                string text = "shit due!";

                Size s = TextRenderer.MeasureText(text, font);

                //args.Graphics.DrawString(text, font, new SolidBrush(Color.White), args.CellBounds.Left + s.Width / 2, args.CellBounds.Top + s.Height / 2, );
                // Customize the cell appearance by your own drawing using Graphics and Bounds of cell from DrawCellEventArgs

                TextRenderer.DrawText(args.Graphics, args.Value.Value.Day.ToString(), new Font("Segoe UI", 10, FontStyle.Regular), args.CellBounds, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }

        }

        private void MeasureText(string txt, Font f)
        {
            Form dummy = new Form();
            Size textSize = TextRenderer.MeasureText(txt, f);
            TextRenderer.DrawText(dummy.CreateGraphics(), txt, f,
                new Rectangle(new Point(10, 10), textSize), Color.Red);

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome to FlowTask " + Mediator.Me.Username + "!";

            TaskCollection.ObservableTaskCollection.CollectionChanged += ObservableTaskCollection_CollectionChanged;

            foreach(Task t in Mediator.Me.Tasks)
                TaskCollection.ObservableTaskCollection.Add(new SelectableTaskDecorator(t));
        }

        private void ObservableTaskCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           lblTasks.Text = string.Format("You have {0} task{1}!", TaskCollection.ObservableTaskCollection.Count, (TaskCollection.ObservableTaskCollection.Count == 1 ? "" : "s"));
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            Mediator.ShowTaskCreate();
        }

        private void btnDeleteClick(object sender, EventArgs e)
        {

            var to_remove = new List<SelectableTaskDecorator>();

            foreach(SelectableTaskDecorator task in TaskCollection.ObservableTaskCollection)
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
                TaskCollection.ObservableTaskCollection.Remove(task);

            to_remove.Clear();
        }

        private void btnLogoutClicked(object sender, EventArgs e)
        {
            Mediator.Logout();
        }
    }
}
