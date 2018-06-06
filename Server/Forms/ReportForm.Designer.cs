namespace Server.Forms
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.byGroupReportGroupBox = new System.Windows.Forms.GroupBox();
            this.subjectsComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.themesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.byGroupReportGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите тип отчёта:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportTypeComboBox.FormattingEnabled = true;
            this.reportTypeComboBox.Items.AddRange(new object[] {
            "По группе"});
            this.reportTypeComboBox.Location = new System.Drawing.Point(16, 42);
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(508, 28);
            this.reportTypeComboBox.TabIndex = 1;
            this.reportTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // byGroupReportGroupBox
            // 
            this.byGroupReportGroupBox.Controls.Add(this.subjectsComboBox);
            this.byGroupReportGroupBox.Controls.Add(this.label4);
            this.byGroupReportGroupBox.Controls.Add(this.saveButton);
            this.byGroupReportGroupBox.Controls.Add(this.themesComboBox);
            this.byGroupReportGroupBox.Controls.Add(this.label3);
            this.byGroupReportGroupBox.Controls.Add(this.groupsComboBox);
            this.byGroupReportGroupBox.Controls.Add(this.label2);
            this.byGroupReportGroupBox.Location = new System.Drawing.Point(4, 76);
            this.byGroupReportGroupBox.Name = "byGroupReportGroupBox";
            this.byGroupReportGroupBox.Size = new System.Drawing.Size(528, 270);
            this.byGroupReportGroupBox.TabIndex = 2;
            this.byGroupReportGroupBox.TabStop = false;
            this.byGroupReportGroupBox.Visible = false;
            // 
            // subjectsComboBox
            // 
            this.subjectsComboBox.DisplayMember = "name";
            this.subjectsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectsComboBox.FormattingEnabled = true;
            this.subjectsComboBox.Location = new System.Drawing.Point(11, 119);
            this.subjectsComboBox.Name = "subjectsComboBox";
            this.subjectsComboBox.Size = new System.Drawing.Size(509, 28);
            this.subjectsComboBox.TabIndex = 8;
            this.subjectsComboBox.ValueMember = "id";
            this.subjectsComboBox.SelectedIndexChanged += new System.EventHandler(this.SubjectsComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(509, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Предмет:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(11, 225);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(509, 30);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сформировать отчёт";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // themesComboBox
            // 
            this.themesComboBox.DisplayMember = "name";
            this.themesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themesComboBox.Enabled = false;
            this.themesComboBox.FormattingEnabled = true;
            this.themesComboBox.Location = new System.Drawing.Point(11, 181);
            this.themesComboBox.Name = "themesComboBox";
            this.themesComboBox.Size = new System.Drawing.Size(509, 28);
            this.themesComboBox.TabIndex = 3;
            this.themesComboBox.ValueMember = "id";
            this.themesComboBox.SelectedIndexChanged += new System.EventHandler(this.ThemesComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(509, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тема:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupsComboBox
            // 
            this.groupsComboBox.DisplayMember = "name";
            this.groupsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupsComboBox.FormattingEnabled = true;
            this.groupsComboBox.Location = new System.Drawing.Point(11, 53);
            this.groupsComboBox.Name = "groupsComboBox";
            this.groupsComboBox.Size = new System.Drawing.Size(509, 28);
            this.groupsComboBox.TabIndex = 1;
            this.groupsComboBox.ValueMember = "id";
            this.groupsComboBox.SelectedIndexChanged += new System.EventHandler(this.groupsComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Группа:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(536, 83);
            this.Controls.Add(this.byGroupReportGroupBox);
            this.Controls.Add(this.reportTypeComboBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование отчётов";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.byGroupReportGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.GroupBox byGroupReportGroupBox;
        private System.Windows.Forms.ComboBox themesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox groupsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox subjectsComboBox;
        private System.Windows.Forms.Label label4;
    }
}