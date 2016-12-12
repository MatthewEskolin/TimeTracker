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
            timer.Interval =1000;//1 second;
            timer.Start();
        }


        private void Handletick(object sender, EventArgs e)
        {
            UpdateViewItemsFromJobItems();



            //var time = stopWatch.Elapsed;

            //var timeString = time.RemoveMilliSeconds().ToString();
            //lblTimer.Text = timeString;
        }

        private void UpdateViewItemsFromJobItems()
        {
            SuspendLayout();
            jobItemBindingSource.RaiseListChangedEvents = true;
            jobItemBindingSource.Filter = "";


            var count = 0;
            foreach (var item in Items)
            {

                var viewItem = ViewItems.Where(x => x.JobItemId == item.JobItemId).FirstOrDefault();
                if (viewItem != null)
                {

                    viewItem.ElapsedTime = item.GetActiveEllapsedTime().RemoveMilliSeconds().ToString();
                    if (viewItem.TimingIsActive)
                    {
                        jobItemBindingSource.ResetItem(count);
                    }
                }
                count++;
            }

            //jobItemBindingSource.ResetBindings(false);

            jobItemBindingSource.SuspendBinding();
            jobItemBindingSource.RaiseListChangedEvents = false;
            jobItemBindingSource.Filter = "1=0";

            ResumeLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetBindingSource();
            dataGridView1.CellFormatting += HighLightRunningTimers;
            dataGridView1.CellFormatting += UpdateRuningTimers;
            dataGridView1.RowHeadersVisible = false;
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
