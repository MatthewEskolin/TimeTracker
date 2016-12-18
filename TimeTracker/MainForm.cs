using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TimeTracker.BLL;
using TimeTracker.DAL;
using TimeTracker.Utlities;
using TimeTracker.Views;

namespace TimeTracker
{
    public partial class MainForm : Form
    {

        public List<JobItem> Items { get; set; }
        public List<JobListViewItem> ViewItems { get; set; }
        public Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            InitializeTimer();


        }

        private void InitializeTimer()
        {
            timer.Tick += Handletick;
            timer.Interval = 1000;
            timer.Start();
        }

        private void Handletick(object sender, EventArgs e)
        {
            UpdateViewItemsFromJobItems();
        }

        private void UpdateViewItemsFromJobItems()
        {
            SuspendLayout();
            jobItemBindingSource.RaiseListChangedEvents = true;
            jobItemBindingSource.Filter = "";


            var count = 0;
            foreach (var item in Items)
            {

                var viewItem = ViewItems.FirstOrDefault(x => x.JobItemId == item.JobItemId);
                if (viewItem != null)
                {
                    //viewItem = JobListViewItem.CreateViewFromJobItem(item);;

                    viewItem.ElapsedTime = item.GetActiveEllapsedTime().RemoveMilliSeconds().ToString();
                    
                    JobListViewItem.CreateViewFromJobItem()

                    if (viewItem.TimingIsActive)
                    {
                        jobItemBindingSource.ResetItem(count);
                    }
                }
                count++;
            }

            jobItemBindingSource.SuspendBinding();
            jobItemBindingSource.RaiseListChangedEvents = false;
            jobItemBindingSource.Filter = "1=0";

            ResumeLayout();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SetBindingSource();
            dataGridView1.CellFormatting += HighLightRunningTimers;
            dataGridView1.CellFormatting += SetButtonVisibility;
            dataGridView1.CellFormatting += UpdateRuningTimers;
            dataGridView1.CellContentClick += dataGridView1_CellClick;
            dataGridView1.RowHeadersVisible = false;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not in our 
            if (e.ColumnIndex == dataGridView1.Columns["StopTimer"].Index && e.RowIndex >= 0)
            {
                var item = GetJobItemByRowIndex(e.RowIndex);
                var timing = item.GetActiveTiming();
                timing.Stop();
            }
        }

        private JobItem GetJobItemByRowIndex(int index)
        {
            var val = (int)dataGridView1.Rows[index].Cells["JobItemId"].Value;
            return Items.FirstOrDefault(x => x.JobItemId == val);
        }


        public static int ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 100;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return (int)inputBox.Value;
        }

        private void SetButtonVisibility(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var isRunning = (bool)dataGridView1.Rows[e.RowIndex].Cells["TimingIsActive"].Value;
            HideCell(dataGridView1, e.RowIndex, isRunning ? "StartTimer" : "StopTimer");
        }

        private void HideCell(DataGridView dataGrid, int rowIndex, string cellName)
        {
            var hiddenButtonStyle = new DataGridViewCellStyle { Padding = new Padding(100, 0, 0, 0) };
            var targetCell = dataGrid.Rows[rowIndex].Cells[cellName];
            targetCell.Style = hiddenButtonStyle;

        }

        private void ShowCelll(DataGridView dataGrid, int rowIndex, string cellName)
        {
            var hiddenButtonStyle = new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) };
            var targetCell = dataGrid.Rows[rowIndex].Cells[cellName];
            targetCell.Style = hiddenButtonStyle;
        }

        private void UpdateRuningTimers(object sender, DataGridViewCellFormattingEventArgs e)
        {



        }


        private void HighLightRunningTimers(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var isRunning = (bool)dataGridView1.Rows[e.RowIndex].Cells["TimingIsActive"].Value;
            if (isRunning)
            {
                e.CellStyle.BackColor = Color.LightGreen;

                


            }


        }

        private void dataGridView1_CellPainting(object sender,
        System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if (this.dataGridView1.Columns["ContactName"].Index ==
                e.ColumnIndex && e.RowIndex >= 0)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
                    e.CellBounds.Y + 1, e.CellBounds.Width - 4,
                    e.CellBounds.Height - 4);

                using (
                    Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // Erase the cell.
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        // Draw the grid lines (only the right and bottom lines;
                        // DataGridView takes care of the others).
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                            e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom - 1);
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                            e.CellBounds.Top, e.CellBounds.Right - 1,
                            e.CellBounds.Bottom);

                        // Draw the inset highlight box.
                        e.Graphics.DrawRectangle(Pens.Blue, newRect);

                        // Draw the text content of the cell, ignoring alignment.
                        if (e.Value != null)
                        {
                            e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
                                Brushes.Crimson, e.CellBounds.X + 2,
                                e.CellBounds.Y + 2, StringFormat.GenericDefault);
                        }
                        e.Handled = true;
                    }
                }
            }
        }



        private void newDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeFormForNewDay();
        }

        private void InitializeFormForNewDay()
        {
            //jobItemBindingSource.DataSource = _DAL.GetDailyItems();
        }


        private void btnNewJobItem_Click(object sender, EventArgs e)
        {
            var form = new NewJobItem();
            form.Closed += UpdateGrid;
            form.ShowDialog();
        }

        private void UpdateGrid(object sender, EventArgs e)
        {
            SetBindingSource();
        }

        public void SetBindingSource()
        {
            Items = _DAL.GetDailyItems();
            ViewItems = Items.Select(JobListViewItem.CreateViewFromJobItem).ToList();


            jobItemBindingSource.DataSource = ViewItems;
        }

    


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var jobGrid = (DataGridView) sender;

            if (jobGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > 0)
            {
                var dataGridViewColumn = jobGrid.Columns["StartTime"];
                if (dataGridViewColumn != null && e.ColumnIndex == dataGridViewColumn.Index)
                {
                        
                }
            }

        }






        private void jobItemBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
