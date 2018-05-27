using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Forms
{
    public partial class AddressChoosingForm : Form
    {
        List<IPAddress> addresses;
        Execute execute;

        public delegate void Execute(IPAddress address);

        public AddressChoosingForm(List<IPAddress> addresses, Execute execute)
        {
            InitializeComponent();
            this.addresses = addresses;
            this.execute = execute;
        }

        private void AddressChoosingForm_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("IP", Type.GetType("System.String")));

            foreach (IPAddress address in addresses)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["IP"] = address.ToString();
                dataTable.Rows.Add(dataRow);
            }

            thingsDataGridView.DataSource = dataTable;
        }

        private void thingsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            chooseButton_Click(sender, null);
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            string choosen = thingsDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            foreach (IPAddress address in addresses)
            {
                if (address.ToString() == choosen)
                {
                    execute(address);
                }
            }
            this.Close();
        }
    }
}
