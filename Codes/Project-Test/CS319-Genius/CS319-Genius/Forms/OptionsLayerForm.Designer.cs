namespace CS319_Genius
{
    partial class OptionsLayerForm
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
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.CheckAppsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.startCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wikiRadio = new System.Windows.Forms.RadioButton();
            this.googleRadio = new System.Windows.Forms.RadioButton();
            this.searchCheck = new System.Windows.Forms.CheckBox();
            this.optionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(105)))), ((int)(((byte)(174)))));
            this.optionsPanel.Controls.Add(this.CheckAppsButton);
            this.optionsPanel.Controls.Add(this.label2);
            this.optionsPanel.Controls.Add(this.startCheck);
            this.optionsPanel.Controls.Add(this.label1);
            this.optionsPanel.Controls.Add(this.wikiRadio);
            this.optionsPanel.Controls.Add(this.googleRadio);
            this.optionsPanel.Controls.Add(this.searchCheck);
            this.optionsPanel.Location = new System.Drawing.Point(12, 12);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(544, 454);
            this.optionsPanel.TabIndex = 0;
            this.optionsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CheckAppsButton
            // 
            this.CheckAppsButton.Location = new System.Drawing.Point(13, 359);
            this.CheckAppsButton.Name = "CheckAppsButton";
            this.CheckAppsButton.Size = new System.Drawing.Size(64, 50);
            this.CheckAppsButton.TabIndex = 6;
            this.CheckAppsButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(83, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Check installed new applications";
            // 
            // startCheck
            // 
            this.startCheck.AutoSize = true;
            this.startCheck.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startCheck.Location = new System.Drawing.Point(30, 274);
            this.startCheck.Name = "startCheck";
            this.startCheck.Size = new System.Drawing.Size(248, 36);
            this.startCheck.TabIndex = 4;
            this.startCheck.Text = "Open at startup";
            this.startCheck.UseVisualStyleBackColor = true;
            this.startCheck.CheckedChanged += new System.EventHandler(this.startCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(103, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "Settings";
            // 
            // wikiRadio
            // 
            this.wikiRadio.AutoSize = true;
            this.wikiRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.wikiRadio.Location = new System.Drawing.Point(77, 194);
            this.wikiRadio.Name = "wikiRadio";
            this.wikiRadio.Size = new System.Drawing.Size(207, 36);
            this.wikiRadio.TabIndex = 2;
            this.wikiRadio.TabStop = true;
            this.wikiRadio.Text = "In Wikipedia";
            this.wikiRadio.UseVisualStyleBackColor = true;
            this.wikiRadio.CheckedChanged += new System.EventHandler(this.wikiRadio_CheckedChanged);
            // 
            // googleRadio
            // 
            this.googleRadio.AutoSize = true;
            this.googleRadio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.googleRadio.Location = new System.Drawing.Point(77, 140);
            this.googleRadio.Name = "googleRadio";
            this.googleRadio.Size = new System.Drawing.Size(175, 36);
            this.googleRadio.TabIndex = 1;
            this.googleRadio.TabStop = true;
            this.googleRadio.Text = "In Google";
            this.googleRadio.UseVisualStyleBackColor = true;
            this.googleRadio.CheckedChanged += new System.EventHandler(this.googleRadio_CheckedChanged);
            // 
            // searchCheck
            // 
            this.searchCheck.AutoSize = true;
            this.searchCheck.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchCheck.Location = new System.Drawing.Point(30, 89);
            this.searchCheck.Name = "searchCheck";
            this.searchCheck.Size = new System.Drawing.Size(364, 36);
            this.searchCheck.TabIndex = 0;
            this.searchCheck.Text = "Search only in one place";
            this.searchCheck.UseVisualStyleBackColor = true;
            this.searchCheck.CheckedChanged += new System.EventHandler(this.searchCheck_CheckedChanged);
            // 
            // OptionsLayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 480);
            this.Controls.Add(this.optionsPanel);
            this.Name = "OptionsLayerForm";
            this.Text = "OptionsLayerForm";
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.CheckBox startCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton wikiRadio;
        private System.Windows.Forms.RadioButton googleRadio;
        private System.Windows.Forms.CheckBox searchCheck;
        private System.Windows.Forms.Button CheckAppsButton;
        private System.Windows.Forms.Label label2;
    }
}