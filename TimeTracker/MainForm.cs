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
            form.ShowDialog();
        }
    }
}
