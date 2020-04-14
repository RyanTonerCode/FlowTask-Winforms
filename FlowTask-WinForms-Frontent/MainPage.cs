using System;
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
        TaskCollection ObservableTaskData = new TaskCollection();

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

            sfDataGrid.DataSource = ObservableTaskData.TaskDetails;

            sfDataGrid.Columns.Add(new GridCheckBoxColumn { MappingName = "Selected", HeaderText = "", AllowCheckBoxOnHeader = true, AllowFiltering = false, CheckBoxSize = new Size(14, 14) });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "AssignmentName", HeaderText = "Assignment Name" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Category", HeaderText = "Category (Subject)" });
            sfDataGrid.Columns.Add(new GridDateTimeColumn() { MappingName = "SubmissionDate", HeaderText = "Due Date" });


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

                var font = new Font("Arial", 8, FontStyle.Regular);

                string text = "shit due!";

                Size s = TextRenderer.MeasureText(text, font);

                args.Graphics.DrawString(text, font, new SolidBrush(Color.White), args.CellBounds.Left + s.Width / 2, args.CellBounds.Top + s.Height / 2);
                // Customize the cell appearance by your own drawing using Graphics and Bounds of cell from DrawCellEventArgs
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
            lblTasks.Text = string.Format("You have {0} task{1}!", Mediator.Me.Tasks.Count, (Mediator.Me.Tasks.Count == 1 ? "" : "s"));

            foreach(Task t in Mediator.Me.Tasks)
            {
                ObservableTaskData.TaskDetails.Add(new SelectableTaskDecorator(t));
            }
        }
    }
}
