using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;

namespace Server
{
    public partial class Journal : Form
    {

        public Journal()
        {
            InitializeComponent();
        }

        private void Journal_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataBaseController.SelectAdapter();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            DataBaseController.DeleteQuery("", "Journal", "Id=" + ID);

            dataGridView1.DataSource = DataBaseController.SelectAdapter();
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
