using System;
using System.Windows.Forms;
using TimeTracker.DAL;

namespace TimeTracker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = _DAL.GetDailyItems();
            jobItemBindingSource.DataSource = _DAL.GetDailyItems();
            dataGridView1.RowHeadersVisible = false;


        }

        private void newDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeFormForNewDay();
        }

        private void InitializeFormForNewDay()
        {
            //dataGridView1.DataSource = _DAL.GetDailyItems();
            jobItemBindingSource.DataSource = _DAL.GetDailyItems();

        }

        private void btnNewJobItem_Click(object sender, EventArgs e)
        {
            var form = new NewJobItem();
            form.Closed += UpdateGrid;
            form.ShowDialog();
        }

        private void UpdateGrid(object sender, EventArgs e)
        {
            jobItemBindingSource.DataSource = _DAL.GetDailyItems();
            //dataGridView1.DataSource = _DAL.GetDailyItems();
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
    }
}
