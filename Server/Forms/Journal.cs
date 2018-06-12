using System;
using System.Windows.Forms;

using Server.Helpers;

namespace Server.Forms
{
    public partial class Journal : Form
    {

        public Journal()
        {
            InitializeComponent();
        }

        private void updateData()
        {
            dataGridView1.DataSource = DatabaseHelper.SelectJournalsAdapter();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100; 
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Regular);
        }

        private void Journal_Load(object sender, EventArgs e)
        {
            updateData();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            DatabaseHelper.DeleteJournalByID(id);
            updateData();
        }

        private void createReportButton_Click(object sender, EventArgs e)
        {
            new ReportForm().ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = dataGridView1.SelectedRows.Count != 0;
        }
    }
}
