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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.totalQuestionLabel = new System.Windows.Forms.Label();
            this.rightQuestionLabel = new System.Windows.Forms.Label();
            this.currentQuestionLabel = new System.Windows.Forms.Label();
            this.thirdAnswerView = new System.Windows.Forms.Label();
            this.secondAnswerView = new System.Windows.Forms.Label();
            this.firstAnswerView = new System.Windows.Forms.Label();
            this.themeLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameLable = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(891, 24);
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
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button2.Location = new System.Drawing.Point(12, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "База данных";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button3.Location = new System.Drawing.Point(12, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "Журнал";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сервер отключен";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(12, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 39);
            this.label2.TabIndex = 6;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(222, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(657, 412);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.totalQuestionLabel);
            this.panel1.Controls.Add(this.rightQuestionLabel);
            this.panel1.Controls.Add(this.currentQuestionLabel);
            this.panel1.Controls.Add(this.thirdAnswerView);
            this.panel1.Controls.Add(this.secondAnswerView);
            this.panel1.Controls.Add(this.firstAnswerView);
            this.panel1.Controls.Add(this.themeLabel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.surnameLable);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 49);
            this.panel1.TabIndex = 4;
            // 
            // totalQuestionLabel
            // 
            this.totalQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.totalQuestionLabel.Location = new System.Drawing.Point(607, 4);
            this.totalQuestionLabel.Name = "totalQuestionLabel";
            this.totalQuestionLabel.Size = new System.Drawing.Size(40, 40);
            this.totalQuestionLabel.TabIndex = 7;
            this.totalQuestionLabel.Text = "100";
            this.totalQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightQuestionLabel
            // 
            this.rightQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rightQuestionLabel.Location = new System.Drawing.Point(561, 4);
            this.rightQuestionLabel.Name = "rightQuestionLabel";
            this.rightQuestionLabel.Size = new System.Drawing.Size(40, 40);
            this.rightQuestionLabel.TabIndex = 6;
            this.rightQuestionLabel.Text = "11";
            this.rightQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentQuestionLabel
            // 
            this.currentQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.currentQuestionLabel.Location = new System.Drawing.Point(515, 4);
            this.currentQuestionLabel.Name = "currentQuestionLabel";
            this.currentQuestionLabel.Size = new System.Drawing.Size(40, 40);
            this.currentQuestionLabel.TabIndex = 5;
            this.currentQuestionLabel.Text = "13";
            this.currentQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thirdAnswerView
            // 
            this.thirdAnswerView.BackColor = System.Drawing.Color.Green;
            this.thirdAnswerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.thirdAnswerView.Location = new System.Drawing.Point(474, 7);
            this.thirdAnswerView.Name = "thirdAnswerView";
            this.thirdAnswerView.Size = new System.Drawing.Size(35, 35);
            this.thirdAnswerView.TabIndex = 4;
            this.thirdAnswerView.Text = "12";
            this.thirdAnswerView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondAnswerView
            // 
            this.secondAnswerView.BackColor = System.Drawing.Color.Maroon;
            this.secondAnswerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.secondAnswerView.Location = new System.Drawing.Point(433, 7);
            this.secondAnswerView.Name = "secondAnswerView";
            this.secondAnswerView.Size = new System.Drawing.Size(35, 35);
            this.secondAnswerView.TabIndex = 3;
            this.secondAnswerView.Text = "11";
            this.secondAnswerView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstAnswerView
            // 
            this.firstAnswerView.BackColor = System.Drawing.Color.Green;
            this.firstAnswerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.firstAnswerView.Location = new System.Drawing.Point(392, 7);
            this.firstAnswerView.Name = "firstAnswerView";
            this.firstAnswerView.Size = new System.Drawing.Size(35, 35);
            this.firstAnswerView.TabIndex = 2;
            this.firstAnswerView.Text = "10";
            this.firstAnswerView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // themeLabel
            // 
            this.themeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.themeLabel.Location = new System.Drawing.Point(183, 0);
            this.themeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.themeLabel.Name = "themeLabel";
            this.themeLabel.Size = new System.Drawing.Size(206, 49);
            this.themeLabel.TabIndex = 1;
            this.themeLabel.Text = "label7";
            this.themeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.nameLabel.Location = new System.Drawing.Point(0, 29);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(183, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Имя";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // surnameLable
            // 
            this.surnameLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.surnameLable.Location = new System.Drawing.Point(0, 0);
            this.surnameLable.Margin = new System.Windows.Forms.Padding(0);
            this.surnameLable.Name = "surnameLable";
            this.surnameLable.Size = new System.Drawing.Size(183, 29);
            this.surnameLable.TabIndex = 0;
            this.surnameLable.Text = "Фамилия";
            this.surnameLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(891, 451);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Тестирование";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Leave += new System.EventHandler(this.Main_Leave);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem остановитьСерверToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label totalQuestionLabel;
        private System.Windows.Forms.Label rightQuestionLabel;
        private System.Windows.Forms.Label currentQuestionLabel;
        private System.Windows.Forms.Label thirdAnswerView;
        private System.Windows.Forms.Label secondAnswerView;
        private System.Windows.Forms.Label firstAnswerView;
        private System.Windows.Forms.Label themeLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label surnameLable;
    }
}

