namespace Server.Forms
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
            this.button1 = new System.Windows.Forms.Button();
            this.databaseButton = new System.Windows.Forms.Button();
            this.journalButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Запустить сервер";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // databaseButton
            // 
            this.databaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.databaseButton.Location = new System.Drawing.Point(12, 54);
            this.databaseButton.Name = "databaseButton";
            this.databaseButton.Size = new System.Drawing.Size(197, 36);
            this.databaseButton.TabIndex = 3;
            this.databaseButton.Text = "Тесты";
            this.databaseButton.UseVisualStyleBackColor = true;
            this.databaseButton.Click += new System.EventHandler(this.databaseButton_Click);
            // 
            // journalButton
            // 
            this.journalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.journalButton.Location = new System.Drawing.Point(12, 96);
            this.journalButton.Name = "journalButton";
            this.journalButton.Size = new System.Drawing.Size(197, 36);
            this.journalButton.TabIndex = 4;
            this.journalButton.Text = "Журнал/Отчёты";
            this.journalButton.UseVisualStyleBackColor = true;
            this.journalButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.statusLabel.Location = new System.Drawing.Point(12, 177);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(197, 39);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Сервер отключен";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectedLabel
            // 
            this.connectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.connectedLabel.Location = new System.Drawing.Point(12, 216);
            this.connectedLabel.Name = "connectedLabel";
            this.connectedLabel.Size = new System.Drawing.Size(197, 39);
            this.connectedLabel.TabIndex = 6;
            this.connectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectedLabel.Click += new System.EventHandler(this.connectedLabel_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 39);
            this.label3.TabIndex = 7;
            this.label3.Text = "IP-адрес сервера:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(12, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 32);
            this.label4.TabIndex = 8;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupsButton
            // 
            this.groupsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupsButton.Location = new System.Drawing.Point(12, 138);
            this.groupsButton.Name = "groupsButton";
            this.groupsButton.Size = new System.Drawing.Size(197, 36);
            this.groupsButton.TabIndex = 9;
            this.groupsButton.Text = "Группы";
            this.groupsButton.UseVisualStyleBackColor = true;
            this.groupsButton.Click += new System.EventHandler(this.groupsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(223, 451);
            this.Controls.Add(this.groupsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.connectedLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.journalButton);
            this.Controls.Add(this.databaseButton);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестирование";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Leave += new System.EventHandler(this.Main_Leave);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button databaseButton;
        private System.Windows.Forms.Button journalButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label connectedLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button groupsButton;
    }
}

