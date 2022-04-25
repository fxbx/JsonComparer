namespace JsonComparer
{
    partial class frmLevellessCompare
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
            this.lstCompares = new System.Windows.Forms.ListBox();
            this.rtbRes = new System.Windows.Forms.RichTextBox();
            this.lblOrigPath = new System.Windows.Forms.Label();
            this.lblNewPath = new System.Windows.Forms.Label();
            this.txtOrigPath = new System.Windows.Forms.TextBox();
            this.txtModPath = new System.Windows.Forms.TextBox();
            this.trvDiff = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // lstCompares
            // 
            this.lstCompares.FormattingEnabled = true;
            this.lstCompares.ItemHeight = 15;
            this.lstCompares.Location = new System.Drawing.Point(12, 12);
            this.lstCompares.Name = "lstCompares";
            this.lstCompares.Size = new System.Drawing.Size(178, 499);
            this.lstCompares.TabIndex = 1;
            this.lstCompares.SelectedIndexChanged += new System.EventHandler(this.lstCompares_SelectedIndexChanged);
            // 
            // rtbRes
            // 
            this.rtbRes.Location = new System.Drawing.Point(196, 103);
            this.rtbRes.Name = "rtbRes";
            this.rtbRes.ReadOnly = true;
            this.rtbRes.Size = new System.Drawing.Size(748, 704);
            this.rtbRes.TabIndex = 2;
            this.rtbRes.Text = "";
            // 
            // lblOrigPath
            // 
            this.lblOrigPath.AutoSize = true;
            this.lblOrigPath.Location = new System.Drawing.Point(196, 12);
            this.lblOrigPath.Name = "lblOrigPath";
            this.lblOrigPath.Size = new System.Drawing.Size(128, 15);
            this.lblOrigPath.TabIndex = 4;
            this.lblOrigPath.Text = "Original JSON Pathway";
            // 
            // lblNewPath
            // 
            this.lblNewPath.AutoSize = true;
            this.lblNewPath.Location = new System.Drawing.Point(196, 56);
            this.lblNewPath.Name = "lblNewPath";
            this.lblNewPath.Size = new System.Drawing.Size(134, 15);
            this.lblNewPath.TabIndex = 5;
            this.lblNewPath.Text = "Modified JSON Pathway";
            // 
            // txtOrigPath
            // 
            this.txtOrigPath.Location = new System.Drawing.Point(196, 30);
            this.txtOrigPath.Name = "txtOrigPath";
            this.txtOrigPath.ReadOnly = true;
            this.txtOrigPath.Size = new System.Drawing.Size(748, 23);
            this.txtOrigPath.TabIndex = 6;
            // 
            // txtModPath
            // 
            this.txtModPath.Location = new System.Drawing.Point(196, 74);
            this.txtModPath.Name = "txtModPath";
            this.txtModPath.ReadOnly = true;
            this.txtModPath.Size = new System.Drawing.Size(748, 23);
            this.txtModPath.TabIndex = 7;
            // 
            // trvDiff
            // 
            this.trvDiff.Location = new System.Drawing.Point(950, 12);
            this.trvDiff.Name = "trvDiff";
            this.trvDiff.Size = new System.Drawing.Size(388, 795);
            this.trvDiff.TabIndex = 8;
            // 
            // frmLevellessCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 819);
            this.Controls.Add(this.trvDiff);
            this.Controls.Add(this.txtModPath);
            this.Controls.Add(this.txtOrigPath);
            this.Controls.Add(this.lblNewPath);
            this.Controls.Add(this.lblOrigPath);
            this.Controls.Add(this.rtbRes);
            this.Controls.Add(this.lstCompares);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLevellessCompare";
            this.Text = "Compare JSON Sections Located In Different Sections";
            this.Load += new System.EventHandler(this.frmLevellessCompare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstCompares;
        private RichTextBox rtbRes;
        private Label lblOrigPath;
        private Label lblNewPath;
        private TextBox txtOrigPath;
        private TextBox txtModPath;
        private TreeView trvDiff;
    }
}