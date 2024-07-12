namespace TimeTracker
{
    partial class MainUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            txtDetails = new TextBox();
            lblSummary = new Label();
            btnReset = new Button();
            btnOpenFolder = new Button();
            lblQuery = new Label();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(40, 76);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(82, 29);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(136, 76);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(82, 29);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtDetails
            // 
            txtDetails.Location = new Point(40, 176);
            txtDetails.Multiline = true;
            txtDetails.Name = "txtDetails";
            txtDetails.ReadOnly = true;
            txtDetails.Size = new Size(369, 348);
            txtDetails.TabIndex = 2;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Location = new Point(45, 32);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(62, 20);
            lblSummary.TabIndex = 3;
            lblSummary.Text = "Summary";
            // 
            // btnReset
            // 
            btnReset.Location = new Point(312, 76);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(97, 29);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new Point(312, 121);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(97, 29);
            btnOpenFolder.TabIndex = 5;
            btnOpenFolder.Text = "Open Folder";
            btnOpenFolder.UseVisualStyleBackColor = true;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // lblQuery
            // 
            lblQuery.AutoSize = true;
            lblQuery.Location = new Point(395, 32);
            lblQuery.Name = "lblQuery";
            lblQuery.Size = new Size(16, 20);
            lblQuery.TabIndex = 6;
            lblQuery.Text = "?";
            lblQuery.Click += lblQuery_Click;
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(7F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 567);
            Controls.Add(lblQuery);
            Controls.Add(btnOpenFolder);
            Controls.Add(btnReset);
            Controls.Add(lblSummary);
            Controls.Add(txtDetails);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainUI";
            Text = "Time Tracker";
            FormClosed += MainUI_FormClosed;
            Load += MainUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private TextBox txtDetails;
        private Label lblSummary;
        private Button btnReset;
        private Button btnOpenFolder;
        private Label lblQuery;
    }
}
