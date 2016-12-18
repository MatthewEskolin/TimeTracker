namespace TimeTracker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNewJobItem = new System.Windows.Forms.Button();
            this.jobItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.JobItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimingIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estimateIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.developerCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTimer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StopTimer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ElapsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1552, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trackToolStripMenuItem
            // 
            this.trackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDayToolStripMenuItem});
            this.trackToolStripMenuItem.Name = "trackToolStripMenuItem";
            this.trackToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.trackToolStripMenuItem.Text = "Track";
            // 
            // newDayToolStripMenuItem
            // 
            this.newDayToolStripMenuItem.Name = "newDayToolStripMenuItem";
            this.newDayToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.newDayToolStripMenuItem.Text = "New Day";
            this.newDayToolStripMenuItem.Click += new System.EventHandler(this.newDayToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JobItemId,
            this.startDateDataGridViewTextBoxColumn,
            this.TimingIsActive,
            this.endDateDataGridViewTextBoxColumn,
            this.billToDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.requestedByDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.estimateIdDataGridViewTextBoxColumn,
            this.developerCodeDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.StartTimer,
            this.StopTimer,
            this.ElapsedTime});
            this.dataGridView1.DataSource = this.jobItemBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1487, 586);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnNewJobItem
            // 
            this.btnNewJobItem.Location = new System.Drawing.Point(12, 40);
            this.btnNewJobItem.Name = "btnNewJobItem";
            this.btnNewJobItem.Size = new System.Drawing.Size(114, 23);
            this.btnNewJobItem.TabIndex = 2;
            this.btnNewJobItem.Text = "New Timer";
            this.btnNewJobItem.UseVisualStyleBackColor = true;
            this.btnNewJobItem.Click += new System.EventHandler(this.btnNewJobItem_Click);
            // 
            // jobItemBindingSource
            // 
            this.jobItemBindingSource.DataSource = typeof(TimeTracker.Views.JobListViewItem);
            this.jobItemBindingSource.CurrentChanged += new System.EventHandler(this.jobItemBindingSource_CurrentChanged);
            // 
            // JobItemId
            // 
            this.JobItemId.DataPropertyName = "JobItemId";
            this.JobItemId.HeaderText = "JobItemId";
            this.JobItemId.Name = "JobItemId";
            this.JobItemId.ReadOnly = true;
            this.JobItemId.Visible = false;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "StartDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TimingIsActive
            // 
            this.TimingIsActive.DataPropertyName = "TimingIsActive";
            this.TimingIsActive.HeaderText = "TimingIsActive";
            this.TimingIsActive.Name = "TimingIsActive";
            this.TimingIsActive.ReadOnly = true;
            this.TimingIsActive.Visible = false;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "EndDate";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // billToDataGridViewTextBoxColumn
            // 
            this.billToDataGridViewTextBoxColumn.DataPropertyName = "BillTo";
            this.billToDataGridViewTextBoxColumn.HeaderText = "BillTo";
            this.billToDataGridViewTextBoxColumn.Name = "billToDataGridViewTextBoxColumn";
            this.billToDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requestedByDataGridViewTextBoxColumn
            // 
            this.requestedByDataGridViewTextBoxColumn.DataPropertyName = "RequestedBy";
            this.requestedByDataGridViewTextBoxColumn.HeaderText = "RequestedBy";
            this.requestedByDataGridViewTextBoxColumn.Name = "requestedByDataGridViewTextBoxColumn";
            this.requestedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estimateIdDataGridViewTextBoxColumn
            // 
            this.estimateIdDataGridViewTextBoxColumn.DataPropertyName = "EstimateId";
            this.estimateIdDataGridViewTextBoxColumn.HeaderText = "EstimateId";
            this.estimateIdDataGridViewTextBoxColumn.Name = "estimateIdDataGridViewTextBoxColumn";
            this.estimateIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // developerCodeDataGridViewTextBoxColumn
            // 
            this.developerCodeDataGridViewTextBoxColumn.DataPropertyName = "DeveloperCode";
            this.developerCodeDataGridViewTextBoxColumn.HeaderText = "DeveloperCode";
            this.developerCodeDataGridViewTextBoxColumn.Name = "developerCodeDataGridViewTextBoxColumn";
            this.developerCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StartTimer
            // 
            this.StartTimer.FillWeight = 70F;
            this.StartTimer.HeaderText = "Start";
            this.StartTimer.Name = "StartTimer";
            this.StartTimer.ReadOnly = true;
            this.StartTimer.Text = "Start";
            this.StartTimer.UseColumnTextForButtonValue = true;
            this.StartTimer.Width = 60;
            // 
            // StopTimer
            // 
            this.StopTimer.HeaderText = "Stop";
            this.StopTimer.Name = "StopTimer";
            this.StopTimer.ReadOnly = true;
            this.StopTimer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StopTimer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StopTimer.Text = "Stop";
            this.StopTimer.ToolTipText = "Stop the Timing";
            this.StopTimer.UseColumnTextForButtonValue = true;
            this.StopTimer.Width = 60;
            // 
            // ElapsedTime
            // 
            this.ElapsedTime.DataPropertyName = "ElapsedTime";
            this.ElapsedTime.HeaderText = "ElapsedTime";
            this.ElapsedTime.Name = "ElapsedTime";
            this.ElapsedTime.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1552, 696);
            this.Controls.Add(this.btnNewJobItem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDayToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNewJobItem;
        private System.Windows.Forms.BindingSource jobItemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TimingIsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn billToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estimateIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn developerCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn StartTimer;
        private System.Windows.Forms.DataGridViewButtonColumn StopTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElapsedTime;
    }
}

