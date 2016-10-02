namespace TimeTracker
{
    partial class NewJobItem
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
            this.cbBillTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRequestedBy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveAndStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDeveloperShortName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbBillTo
            // 
            this.cbBillTo.DisplayMember = "Customers";
            this.cbBillTo.FormattingEnabled = true;
            this.cbBillTo.Location = new System.Drawing.Point(96, 83);
            this.cbBillTo.Name = "cbBillTo";
            this.cbBillTo.Size = new System.Drawing.Size(121, 21);
            this.cbBillTo.TabIndex = 2;
            this.cbBillTo.ValueMember = "Customers";
            this.cbBillTo.SelectedIndexChanged += new System.EventHandler(this.cbBillTo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bill To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(96, 110);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(412, 20);
            this.tbDescription.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Requested By";
            // 
            // cbRequestedBy
            // 
            this.cbRequestedBy.FormattingEnabled = true;
            this.cbRequestedBy.Location = new System.Drawing.Point(96, 139);
            this.cbRequestedBy.Name = "cbRequestedBy";
            this.cbRequestedBy.Size = new System.Drawing.Size(121, 21);
            this.cbRequestedBy.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Developer";
            // 
            // btnSaveAndStart
            // 
            this.btnSaveAndStart.Location = new System.Drawing.Point(8, 199);
            this.btnSaveAndStart.Name = "btnSaveAndStart";
            this.btnSaveAndStart.Size = new System.Drawing.Size(120, 23);
            this.btnSaveAndStart.TabIndex = 13;
            this.btnSaveAndStart.Text = "Save And Start Work";
            this.btnSaveAndStart.UseVisualStyleBackColor = true;
            this.btnSaveAndStart.Click += new System.EventHandler(this.btnSaveAndStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(142, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDeveloperShortName
            // 
            this.lblDeveloperShortName.AutoSize = true;
            this.lblDeveloperShortName.Location = new System.Drawing.Point(96, 168);
            this.lblDeveloperShortName.Name = "lblDeveloperShortName";
            this.lblDeveloperShortName.Size = new System.Drawing.Size(35, 13);
            this.lblDeveloperShortName.TabIndex = 15;
            this.lblDeveloperShortName.Text = "label2";
            // 
            // NewJobItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 250);
            this.Controls.Add(this.lblDeveloperShortName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbRequestedBy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbBillTo);
            this.Name = "NewJobItem";
            this.Text = "NewJobItem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbBillTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRequestedBy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveAndStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDeveloperShortName;
    }
}