namespace Server.Forms
{
    partial class groupModal
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
            this.doThingButton = new System.Windows.Forms.Button();
            this.thingTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // doThingButton
            // 
            this.doThingButton.Location = new System.Drawing.Point(372, 12);
            this.doThingButton.Name = "doThingButton";
            this.doThingButton.Size = new System.Drawing.Size(100, 26);
            this.doThingButton.TabIndex = 0;
            this.doThingButton.Text = "button1";
            this.doThingButton.UseVisualStyleBackColor = true;
            // 
            // thingTextBox
            // 
            this.thingTextBox.Location = new System.Drawing.Point(12, 12);
            this.thingTextBox.MaxLength = 50;
            this.thingTextBox.Name = "thingTextBox";
            this.thingTextBox.Size = new System.Drawing.Size(354, 26);
            this.thingTextBox.TabIndex = 1;
            this.thingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thingTextBox_KeyDown);
            // 
            // groupModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 49);
            this.Controls.Add(this.thingTextBox);
            this.Controls.Add(this.doThingButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "groupModal";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "groupModal";
            this.Load += new System.EventHandler(this.groupModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doThingButton;
        private System.Windows.Forms.TextBox thingTextBox;
    }
}