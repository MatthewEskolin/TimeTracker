using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TimeTracker.DAL;
using TimeTracker.Views;

namespace TimeTracker
{
    public partial class MainForm : Form
    {

        public Stopwatch stopWatch = new Stopwatch();
        public Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            InitializeTimer();


        }

        private void InitializeTimer()
        {
            timer.Tick += Handletick;
            timer.Interval = 1;//1 second;
            timer.Start();
            
            stopWatch.Start();
        }


        private void Handletick(object sender, EventArgs e)
        {
            var time = stopWatch.Elapsed;
            var timeString = RemoveMilliSeconds(time).ToString();
            lblTimer.Text = timeString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetBindingSource();
            dataGridView1.CellFormatting += HighLightRunningTimers;
            dataGridView1.RowHeadersVisible = false;
        }

        private void HighLightRunningTimers(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var isRunning = (bool)dataGridView1.Rows[e.RowIndex].Cells["TimingIsActive"].Value;
            if (isRunning)
            {
                e.CellStyle.BackColor = Color.Green;
            }


        }

        public TimeSpan RemoveMilliSeconds(TimeSpan source)
        {
            var rtn = new TimeSpan(source.Hours, source.Minutes, source.Seconds);
            return rtn;
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
            var items = _DAL.GetDailyItems();
            var viewItems = items.Select(JobListViewItem.CreateViewFromJobItem).ToList();
            jobItemBindingSource.DataSource = viewItems;
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
