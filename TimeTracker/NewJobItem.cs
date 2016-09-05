using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TimeTracker.DAL;

namespace TimeTracker
{
    public partial class NewJobItem : Form
    {
        private DateTime StartTime = DateTime.Now;

        public NewJobItem()
        {
            InitializeComponent();
            lblStartTime.Text = StartTime.ToString("G");
            BindData();
        }

        private void BindData()
        {
            BindCustomers();
            BindDevelopers();
            BindRequestedBy();



        }

        private void BindRequestedBy()
        {
            //initial
            throw new NotImplementedException();
        }

        private void BindDevelopers()
        {
            var devId = Properties.Settings.Default.Developer;
            var devRec = _DAL.getDeveloperById(devId);
            lblDeveloperShortName.Text = devRec.DeveloperShortName;

            var toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.None;

            //toolTip.IsBalloon = true;
            toolTip.SetToolTip(lblDeveloperShortName, devRec.DeveloperName);
        }

        private void BindCustomers()
        {
            cbBillTo.DataSource = _DAL.GetCustomers();
            cbBillTo.DisplayMember = "CustomerName";
            cbBillTo.ValueMember = "CustomerId";
            cbBillTo.SelectedIndex = -1;

        }

        private void btnSaveAndStart_Click(object sender, EventArgs e)
        {
            var item = new DJobItem
            {
                StartDate = StartTime,
                CustomerId = GetCustomerId()
            };

            var ctx = new TimeTrackerEntities();
            ctx.DJobItems.Add(item);
            ctx.SaveChanges();




        }

        private int GetCustomerId()
        {
            //Create New Customer If does not exist.
            var ctx = new TimeTrackerEntities();

            string selectedBillTo = cbBillTo.GetItemText(cbBillTo.SelectedItem);
            if (selectedBillTo.Length == 0)
            {
                var newBillTo = cbBillTo.Text;
                if (ctx.DCustomers.Any(x => x.CustomerName == newBillTo))
                {
                    var custRec = ctx.DCustomers.FirstOrDefault( x => x.CustomerName.ToUpper() ==  newBillTo.ToUpper());
                    if (custRec != null) return custRec.CustomerId;
                }
                else
                {
                    //create new Customer with input text.
                    var newCustomer = new DCustomer {CustomerName = newBillTo};
                    ctx.DCustomers.Add(newCustomer);
                    ctx.SaveChanges();
                    return newCustomer.CustomerId;

                }
            }
            else
            {
                return Int32.Parse(cbBillTo.SelectedValue.ToString());
            }

            throw new DataException("Wierd Data Encountered!");
        }

        private void cbBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
    }
}
