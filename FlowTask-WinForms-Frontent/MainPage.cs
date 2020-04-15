﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlowTask_Backend;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Interactivity;
using Syncfusion.WinForms.Input;

namespace FlowTask_WinForms_Frontent
{
    public partial class MainPage : Form
    {

        public MainPage()
        {
            InitializeComponent();

            DoubleBuffered = true;

            sfCalendarOverview.DrawCell += SfCalendarDrawCell;

            sfCalendarOverview.SelectedDate = DateTime.Today.AddDays(1);
            sfCalendarOverview.SelectedDate = DateTime.Today;

            sfDataGrid.DataSource = TaskCollection.ObservableTaskCollection;

            sfDataGrid.Columns.Add(new GridCheckBoxColumn { MappingName = "Selected", HeaderText = "", AllowCheckBoxOnHeader = true, AllowFiltering = false, CheckBoxSize = new Size(14, 14) });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "AssignmentName", HeaderText = "Assignment Name" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Category", HeaderText = "Category (Subject)" });
            sfDataGrid.Columns.Add(new GridDateTimeColumn() { MappingName = "SubmissionDate", HeaderText = "Due Date" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "Selected", HeaderText = "Remaining Flow Steps" });

            sfDataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Multiple;

            //sfDataGrid.SelectionController = new RowSelectionController(sfDataGrid);
            sfDataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.None;

            sfDataGrid.QueryCellStyle += SfDataGrid_QueryCellStyle;

            sfCalendarOverview.SelectionChanged += SfCalendarOverview_SelectionChanged;
        }

        private void drawDue(DateTime here)
        {
            Font f = new Font("Segoe UI Semibold", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Font f2 = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);

            flowLayout.FlowDirection = FlowDirection.TopDown;

            flowLayout.ForeColor = Color.White;
            flowLayout.BackColor = Color.White;

            flowLayout.Controls.Clear();
            Label header = new Label()
            {
                Font = f,
                Text = string.Format("Tasks due on {0}", here.ToString("dddd, dd MMMM yyyy")),
                Padding = new Padding(4, 4, 4, 4),
                Height = 40,
                Width = flowLayout.Width,
                ForeColor = Color.Black,
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
            };

            flowLayout.Controls.Add(header);

            int number = 0;
            foreach (var task in TaskCollection.ObservableTaskCollection)
                if (here.Day == task.SubmissionDate.Day && here.Month == task.SubmissionDate.Month && here.Year == task.SubmissionDate.Year)
                {
                    Label info = new Label()
                    {
                        Font = f2,
                        Text = string.Format("{0}. {1} ({2})", ++number, task.AssignmentName, task.Category),
                        Padding = new Padding(15, 4, 4, 4),
                        Height = 35,
                        BackColor = Color.White,
                        ForeColor = task.DrawColor,
                        Width = flowLayout.Width,
                        BorderStyle = BorderStyle.FixedSingle
                    };
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

            var color = TaskCollection.ObservableTaskCollection[index].DrawColor;
            if (e.Column.MappingName != "Selected")
            {
                e.Style.BackColor = color;
            }
        }

        void SfCalendarDrawCell(SfCalendar sender, Syncfusion.WinForms.Input.Events.DrawCellEventArgs args)
        {
            args.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            if (args.IsTrailingDate)
            {
                // Customize the cell appearance using options from DrawCellEventArgs
                args.ForeColor = Color.DarkGray;
            }

            List<SelectableTaskDecorator> to_draw = new List<SelectableTaskDecorator>();

            DateTime here = args.Value.Value;

            foreach (var task in TaskCollection.ObservableTaskCollection)
                if (here.Day == task.SubmissionDate.Day && here.Month == task.SubmissionDate.Month && here.Year == task.SubmissionDate.Year)
                    to_draw.Add(task);

            int startPosition = 0;

            foreach (var task in to_draw)
            {
                args.Handled = true;

                TextRenderer.DrawText(args.Graphics, args.Value.Value.Day.ToString(), new Font("Segoe UI", 10, FontStyle.Regular), args.CellBounds, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                args.Graphics.FillRectangle(new SolidBrush(task.DrawColor), new Rectangle((args.CellBounds.X + (args.CellBounds.Width - args.CellBounds.Width / 2)) - (to_draw.Count * 2) - (to_draw.Count * 6) - startPosition, (args.CellBounds.Y + (args.CellBounds.Height - 20)), 12, 12));
                startPosition -= 18;
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

            drawDue(DateTime.Today);
        }

        private void ObservableTaskCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(TaskCollection.ObservableTaskCollection.Count == 0)
                lblTasks.Text = "Congrats, you have no tasks left!";
            else
                lblTasks.Text = string.Format("You have {0} task{1}!", TaskCollection.ObservableTaskCollection.Count, (TaskCollection.ObservableTaskCollection.Count == 1 ? "" : "s"));

            drawDue(sfCalendarOverview.SelectedDate.Value);
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

        private void btnView_Click(object sender, EventArgs e)
        {

        }
    }
}
