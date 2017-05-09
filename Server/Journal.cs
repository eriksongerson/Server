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
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Regular);
        }
    }
}
