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
            dataGridView1.DataSource = _DAL.GetDailyItems();
            
            DataGridViewButtonColumn startButton = new DataGridViewButtonColumn();
            startButton.HeaderText = "Start";
            startButton.Text = "Start";
            startButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(startButton);

            //changed

        }

        private void newDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeFormForNewDay();
        }

        private void InitializeFormForNewDay()
        {
            dataGridView1.DataSource = _DAL.GetDailyItems();

        }

        private void btnNewJobItem_Click(object sender, EventArgs e)
        {
            var form = new NewJobItem();
            form.Closed += UpdateGrid;
            form.ShowDialog();
        }

        private void UpdateGrid(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _DAL.GetDailyItems();
        }
    }
}
