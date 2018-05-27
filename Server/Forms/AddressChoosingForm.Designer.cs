namespace Server.Forms
{
    partial class AddressChoosingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.thingsDataGridView = new System.Windows.Forms.DataGridView();
            this.chooseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Система нашла несколько сетевых адаптеров на этом компьютере. Выберите адрес, кот" +
    "орый будет использоваться системой контроля знаний:";
            // 
            // thingsDataGridView
            // 
            this.thingsDataGridView.AllowUserToAddRows = false;
            this.thingsDataGridView.AllowUserToDeleteRows = false;
            this.thingsDataGridView.AllowUserToResizeColumns = false;
            this.thingsDataGridView.AllowUserToResizeRows = false;
            this.thingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.thingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.thingsDataGridView.ColumnHeadersVisible = false;
            this.thingsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.thingsDataGridView.Location = new System.Drawing.Point(12, 76);
            this.thingsDataGridView.Name = "thingsDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.thingsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.thingsDataGridView.RowHeadersVisible = false;
            this.thingsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.thingsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.thingsDataGridView.Size = new System.Drawing.Size(417, 186);
            this.thingsDataGridView.TabIndex = 1;
            this.thingsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.thingsDataGridView_CellDoubleClick);
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(12, 270);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(417, 30);
            this.chooseButton.TabIndex = 2;
            this.chooseButton.Text = "Выбрать";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // AddressChoosingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 306);
            this.ControlBox = false;
            this.Controls.Add(this.chooseButton);
            this.Controls.Add(this.thingsDataGridView);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddressChoosingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите IP-адрес для использования";
            this.Load += new System.EventHandler(this.AddressChoosingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thingsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView thingsDataGridView;
        private System.Windows.Forms.Button chooseButton;
    }
}