namespace CS319_Genius
{
    partial class InterfaceManager
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
            this.inputBox = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.TextBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputBox.Location = new System.Drawing.Point(5, 1203);
            this.inputBox.Margin = new System.Windows.Forms.Padding(5);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(649, 123);
            this.inputBox.TabIndex = 4;
            this.inputBox.Text = "";
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(125)))), ((int)(((byte)(184)))));
            this.sendButton.ForeColor = System.Drawing.Color.Black;
            this.sendButton.Location = new System.Drawing.Point(664, 1203);
            this.sendButton.Margin = new System.Windows.Forms.Padding(5);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(154, 123);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(105)))), ((int)(((byte)(174)))));
            this.title.Location = new System.Drawing.Point(5, 111);
            this.title.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(649, 111);
            this.title.TabIndex = 6;
            this.title.Text = "Chat Log:";
            this.title.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.title.Click += new System.EventHandler(this.title_Click);
            // 
            // logBox
            // 
            this.logBox.AcceptsReturn = true;
            this.logBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox.Location = new System.Drawing.Point(12, 256);
            this.logBox.Margin = new System.Windows.Forms.Padding(5);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(829, 920);
            this.logBox.TabIndex = 7;
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.White;
            this.helpButton.BackgroundImage = global::CS319_Genius.Properties.Resources.question;
            this.helpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.helpButton.Location = new System.Drawing.Point(697, 146);
            this.helpButton.Margin = new System.Windows.Forms.Padding(5);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(121, 100);
            this.helpButton.TabIndex = 8;
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.BackColor = System.Drawing.Color.White;
            this.optionsButton.BackgroundImage = global::CS319_Genius.Properties.Resources.cog;
            this.optionsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.optionsButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.optionsButton.Location = new System.Drawing.Point(570, 146);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(5);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(121, 100);
            this.optionsButton.TabIndex = 1;
            this.optionsButton.UseVisualStyleBackColor = false;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // InterfaceManager
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(823, 1379);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.title);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(823, 1379);
            this.MinimizeBox = false;
            this.Name = "InterfaceManager";
            this.Padding = new System.Windows.Forms.Padding(21, 62, 21, 21);
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Genius Smart Assistant";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

 

        #endregion
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.RichTextBox inputBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button helpButton;
    }
}

