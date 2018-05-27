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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьСерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьСерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.редактироватьБазуДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.databaseButton = new System.Windows.Forms.Button();
            this.journalButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupsButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(223, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запуститьСерверToolStripMenuItem,
            this.остановитьСерверToolStripMenuItem,
            this.toolStripMenuItem2,
            this.редактироватьБазуДанныхToolStripMenuItem,
            this.журналToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // запуститьСерверToolStripMenuItem
            // 
            this.запуститьСерверToolStripMenuItem.Name = "запуститьСерверToolStripMenuItem";
            this.запуститьСерверToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.запуститьСерверToolStripMenuItem.Text = "Запустить сервер";
            this.запуститьСерверToolStripMenuItem.Click += new System.EventHandler(this.запуститьСерверToolStripMenuItem_Click);
            // 
            // остановитьСерверToolStripMenuItem
            // 
            this.остановитьСерверToolStripMenuItem.Enabled = false;
            this.остановитьСерверToolStripMenuItem.Name = "остановитьСерверToolStripMenuItem";
            this.остановитьСерверToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.остановитьСерверToolStripMenuItem.Text = "Остановить сервер";
            this.остановитьСерверToolStripMenuItem.Click += new System.EventHandler(this.остановитьСерверToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(259, 6);
            // 
            // редактироватьБазуДанныхToolStripMenuItem
            // 
            this.редактироватьБазуДанныхToolStripMenuItem.Name = "редактироватьБазуДанныхToolStripMenuItem";
            this.редактироватьБазуДанныхToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.редактироватьБазуДанныхToolStripMenuItem.Text = "Редактировать базу данных";
            // 
            // журналToolStripMenuItem
            // 
            this.журналToolStripMenuItem.Name = "журналToolStripMenuItem";
            this.журналToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.журналToolStripMenuItem.Text = "Журнал";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(259, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(12, 28);
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
            this.databaseButton.Location = new System.Drawing.Point(12, 70);
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
            this.journalButton.Location = new System.Drawing.Point(12, 112);
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
            this.statusLabel.Location = new System.Drawing.Point(12, 193);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(197, 39);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Сервер отключен";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectedLabel
            // 
            this.connectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.connectedLabel.Location = new System.Drawing.Point(12, 232);
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
            this.groupsButton.Location = new System.Drawing.Point(12, 154);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестирование";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Leave += new System.EventHandler(this.Main_Leave);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запуститьСерверToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьБазуДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button databaseButton;
        private System.Windows.Forms.Button journalButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem остановитьСерверToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.Label connectedLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button groupsButton;
    }
}

