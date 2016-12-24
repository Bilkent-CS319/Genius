namespace CS319_Genius
{
    partial class HelpLayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpLayerForm));
            this.HelpLayerPanel = new System.Windows.Forms.Panel();
            this.helpInfoBox = new System.Windows.Forms.TextBox();
            this.helpTitle = new System.Windows.Forms.Label();
            this.HelpLayerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HelpLayerPanel
            // 
            this.HelpLayerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(105)))), ((int)(((byte)(174)))));
            this.HelpLayerPanel.Controls.Add(this.helpInfoBox);
            this.HelpLayerPanel.Controls.Add(this.helpTitle);
            this.HelpLayerPanel.Location = new System.Drawing.Point(12, 12);
            this.HelpLayerPanel.Name = "HelpLayerPanel";
            this.HelpLayerPanel.Size = new System.Drawing.Size(688, 655);
            this.HelpLayerPanel.TabIndex = 0;
            // 
            // helpInfoBox
            // 
            this.helpInfoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(105)))), ((int)(((byte)(174)))));
            this.helpInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpInfoBox.Location = new System.Drawing.Point(20, 66);
            this.helpInfoBox.Multiline = true;
            this.helpInfoBox.Name = "helpInfoBox";
            this.helpInfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpInfoBox.Size = new System.Drawing.Size(639, 560);
            this.helpInfoBox.TabIndex = 2;
            this.helpInfoBox.Text = resources.GetString("helpInfoBox.Text");
            // 
            // helpTitle
            // 
            this.helpTitle.AutoSize = true;
            this.helpTitle.Font = new System.Drawing.Font("Modern No. 20", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.helpTitle.Location = new System.Drawing.Point(190, 13);
            this.helpTitle.Name = "helpTitle";
            this.helpTitle.Size = new System.Drawing.Size(283, 50);
            this.helpTitle.TabIndex = 1;
            this.helpTitle.Text = "Help Section";
            // 
            // HelpLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 1012);
            this.Controls.Add(this.HelpLayerPanel);
            this.Name = "HelpLayerForm";
            this.Text = "HelpLayerForm";
            this.HelpLayerPanel.ResumeLayout(false);
            this.HelpLayerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel HelpLayerPanel;
        private System.Windows.Forms.TextBox helpInfoBox;
        private System.Windows.Forms.Label helpTitle;
    }
}