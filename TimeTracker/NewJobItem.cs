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
            cbRequestedBy.DataSource = _DAL.GetRequestors();
            cbRequestedBy.DisplayMember = "RequestorName";
            cbRequestedBy.ValueMember = "RequestorId";
        }

        private void BindDevelopers()
        {
            var devId = Properties.Settings.Default.Developer;
            var devRec = _DAL.getDeveloperById(devId);
            if (devRec != null)
            {
            lblDeveloperShortName.Text = devRec.DeveloperShortName;

            var toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.None;

            //toolTip.IsBalloon = true;
            toolTip.SetToolTip(lblDeveloperShortName, devRec.DeveloperName);
                
            }
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
                CustomerId = GetCustomerId(),
                RequestorId = GetRequestorId(),
                Description = tbDescription.Text,
                EstimateId = null,
                DeveloperId =Properties.Settings.Default.Developer
            };

            var ctx = new TimeTrackerEntities();
            ctx.DJobItems.Add(item);
            ctx.SaveChanges();

            this.Close();

            //TODO Start a new Timing.
        }


        private int GetRequestorId()
        {

            var ctx = new TimeTrackerEntities();

            string selectedRequestor =  cbRequestedBy.GetItemText(cbRequestedBy.SelectedItem);
            if (selectedRequestor.Length == 0)
            {
                var newRequestor = cbRequestedBy.Text;
                if (ctx.DRequestors.Any(x => x.RequestorName == newRequestor))
                {
                    var custRec = ctx.DRequestors.FirstOrDefault(x => x.RequestorName.ToUpper() == newRequestor.ToUpper());
                    if (custRec != null) return custRec.RequestorId;
                }
                else
                {
                    //create new Customer with input text.
                    var newRec = new DRequestor() {RequestorName = newRequestor};
                    ctx.DRequestors.Add(newRec);
                    ctx.SaveChanges();
                    return newRec.RequestorId;
                }
            }
            else
            {
                return Int32.Parse(cbBillTo.SelectedValue.ToString());
            }

            throw new DataException("Inconsistent Data.");


        }

        private int GetCustomerId()
        {
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
