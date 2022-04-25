namespace JsonComparer
{
    partial class frmMain
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
            this.rtbInputLeft = new System.Windows.Forms.RichTextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.rtbInputRight = new System.Windows.Forms.RichTextBox();
            this.chkIncludeMatches = new System.Windows.Forms.CheckBox();
            this.chkChildrenCompare = new System.Windows.Forms.CheckBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.trvDiff = new System.Windows.Forms.TreeView();
            this.rtbRightMod = new System.Windows.Forms.RichTextBox();
            this.rtbLeftMod = new System.Windows.Forms.RichTextBox();
            this.lblLeftMod = new System.Windows.Forms.Label();
            this.lblRightMod = new System.Windows.Forms.Label();
            this.lblResTxt = new System.Windows.Forms.Label();
            this.lblResTrv = new System.Windows.Forms.Label();
            this.btnLevelless = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbInputLeft
            // 
            this.rtbInputLeft.Location = new System.Drawing.Point(12, 27);
            this.rtbInputLeft.Name = "rtbInputLeft";
            this.rtbInputLeft.Size = new System.Drawing.Size(455, 405);
            this.rtbInputLeft.TabIndex = 0;
            this.rtbInputLeft.Text = "";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(1141, 864);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(231, 49);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Beautify and Compare";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(934, 27);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.ReadOnly = true;
            this.rtbOutput.Size = new System.Drawing.Size(675, 405);
            this.rtbOutput.TabIndex = 2;
            this.rtbOutput.Text = "";
            // 
            // rtbInputRight
            // 
            this.rtbInputRight.Location = new System.Drawing.Point(12, 453);
            this.rtbInputRight.Name = "rtbInputRight";
            this.rtbInputRight.Size = new System.Drawing.Size(455, 405);
            this.rtbInputRight.TabIndex = 3;
            this.rtbInputRight.Text = "";
            // 
            // chkIncludeMatches
            // 
            this.chkIncludeMatches.AutoSize = true;
            this.chkIncludeMatches.Checked = true;
            this.chkIncludeMatches.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeMatches.Location = new System.Drawing.Point(179, 880);
            this.chkIncludeMatches.Name = "chkIncludeMatches";
            this.chkIncludeMatches.Size = new System.Drawing.Size(354, 19);
            this.chkIncludeMatches.TabIndex = 5;
            this.chkIncludeMatches.Text = "Include Matching Nodes in JSON Diff (Text Field and TreeView)";
            this.chkIncludeMatches.UseVisualStyleBackColor = true;
            // 
            // chkChildrenCompare
            // 
            this.chkChildrenCompare.AutoSize = true;
            this.chkChildrenCompare.Checked = true;
            this.chkChildrenCompare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChildrenCompare.Location = new System.Drawing.Point(581, 880);
            this.chkChildrenCompare.Name = "chkChildrenCompare";
            this.chkChildrenCompare.Size = new System.Drawing.Size(422, 19);
            this.chkChildrenCompare.TabIndex = 6;
            this.chkChildrenCompare.Text = "Display Node Counts and Node Count Differences (Text Field and TreeView)";
            this.chkChildrenCompare.UseVisualStyleBackColor = true;
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Location = new System.Drawing.Point(12, 9);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(80, 15);
            this.lblLeft.TabIndex = 7;
            this.lblLeft.Text = "Original JSON";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(12, 435);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(86, 15);
            this.lblRight.TabIndex = 8;
            this.lblRight.Text = "Modified JSON";
            // 
            // trvDiff
            // 
            this.trvDiff.Location = new System.Drawing.Point(934, 453);
            this.trvDiff.Name = "trvDiff";
            this.trvDiff.Size = new System.Drawing.Size(675, 405);
            this.trvDiff.TabIndex = 9;
            // 
            // rtbRightMod
            // 
            this.rtbRightMod.Location = new System.Drawing.Point(473, 453);
            this.rtbRightMod.Name = "rtbRightMod";
            this.rtbRightMod.ReadOnly = true;
            this.rtbRightMod.Size = new System.Drawing.Size(455, 405);
            this.rtbRightMod.TabIndex = 11;
            this.rtbRightMod.Text = "";
            // 
            // rtbLeftMod
            // 
            this.rtbLeftMod.Location = new System.Drawing.Point(473, 27);
            this.rtbLeftMod.Name = "rtbLeftMod";
            this.rtbLeftMod.ReadOnly = true;
            this.rtbLeftMod.Size = new System.Drawing.Size(455, 405);
            this.rtbLeftMod.TabIndex = 10;
            this.rtbLeftMod.Text = "";
            // 
            // lblLeftMod
            // 
            this.lblLeftMod.AutoSize = true;
            this.lblLeftMod.Location = new System.Drawing.Point(473, 9);
            this.lblLeftMod.Name = "lblLeftMod";
            this.lblLeftMod.Size = new System.Drawing.Size(118, 15);
            this.lblLeftMod.TabIndex = 12;
            this.lblLeftMod.Text = "Original JSON, Tidied";
            // 
            // lblRightMod
            // 
            this.lblRightMod.AutoSize = true;
            this.lblRightMod.Location = new System.Drawing.Point(473, 435);
            this.lblRightMod.Name = "lblRightMod";
            this.lblRightMod.Size = new System.Drawing.Size(124, 15);
            this.lblRightMod.TabIndex = 13;
            this.lblRightMod.Text = "Modified JSON, Tidied";
            // 
            // lblResTxt
            // 
            this.lblResTxt.AutoSize = true;
            this.lblResTxt.Location = new System.Drawing.Point(941, 9);
            this.lblResTxt.Name = "lblResTxt";
            this.lblResTxt.Size = new System.Drawing.Size(71, 15);
            this.lblResTxt.TabIndex = 14;
            this.lblResTxt.Text = "Results, Text";
            // 
            // lblResTrv
            // 
            this.lblResTrv.AutoSize = true;
            this.lblResTrv.Location = new System.Drawing.Point(934, 435);
            this.lblResTrv.Name = "lblResTrv";
            this.lblResTrv.Size = new System.Drawing.Size(96, 15);
            this.lblResTrv.TabIndex = 15;
            this.lblResTrv.Text = "Results, TreeView";
            // 
            // btnLevelless
            // 
            this.btnLevelless.Enabled = false;
            this.btnLevelless.Location = new System.Drawing.Point(1378, 864);
            this.btnLevelless.Name = "btnLevelless";
            this.btnLevelless.Size = new System.Drawing.Size(231, 49);
            this.btnLevelless.TabIndex = 16;
            this.btnLevelless.Text = "Perform Level-Independent Compares";
            this.btnLevelless.UseVisualStyleBackColor = true;
            this.btnLevelless.Click += new System.EventHandler(this.btnLevelless_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1631, 931);
            this.Controls.Add(this.btnLevelless);
            this.Controls.Add(this.lblResTrv);
            this.Controls.Add(this.lblResTxt);
            this.Controls.Add(this.lblRightMod);
            this.Controls.Add(this.lblLeftMod);
            this.Controls.Add(this.rtbRightMod);
            this.Controls.Add(this.rtbLeftMod);
            this.Controls.Add(this.trvDiff);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.chkChildrenCompare);
            this.Controls.Add(this.chkIncludeMatches);
            this.Controls.Add(this.rtbInputRight);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.rtbInputLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "JSON Diff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox rtbInputLeft;
        private Button btnGo;
        private RichTextBox rtbOutput;
        private RichTextBox rtbInputRight;
        private CheckBox chkIncludeMatches;
        private CheckBox chkChildrenCompare;
        private Label lblLeft;
        private Label lblRight;
        private TreeView trvDiff;
        private RichTextBox rtbRightMod;
        private RichTextBox rtbLeftMod;
        private Label lblLeftMod;
        private Label lblRightMod;
        private Label lblResTxt;
        private Label lblResTrv;
        private Button btnLevelless;
    }
}