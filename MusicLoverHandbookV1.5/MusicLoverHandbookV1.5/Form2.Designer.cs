namespace MusicLoverHandbookV1._5
{
    partial class Form2
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.songTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(25, 120);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 29);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(133, 120);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 29);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // artistTextBox
            // 
            this.artistTextBox.BackColor = System.Drawing.Color.White;
            this.artistTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.artistTextBox.Location = new System.Drawing.Point(44, 33);
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(153, 20);
            this.artistTextBox.TabIndex = 5;
            this.artistTextBox.Text = "Type in an artist...";
            this.artistTextBox.Enter += new System.EventHandler(this.artistTextBox_Enter);
            this.artistTextBox.Leave += new System.EventHandler(this.artistTextBox_Leave);
            // 
            // songTextBox
            // 
            this.songTextBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.songTextBox.Location = new System.Drawing.Point(44, 75);
            this.songTextBox.Name = "songTextBox";
            this.songTextBox.Size = new System.Drawing.Size(153, 20);
            this.songTextBox.TabIndex = 6;
            this.songTextBox.Text = "Type in a song name...";
            this.songTextBox.Enter += new System.EventHandler(this.songTextBox_Enter);
            this.songTextBox.Leave += new System.EventHandler(this.songTextBox_Leave);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 161);
            this.Controls.Add(this.songTextBox);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Adding";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.TextBox artistTextBox;
        public System.Windows.Forms.TextBox songTextBox;
    }
}