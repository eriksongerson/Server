using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Server.Helpers;
using Server.Models;

namespace Server.Forms
{
    public partial class GroupsForm : Form
    {
        public GroupsForm()
        {
            InitializeComponent();
        }

        private void GroupsForm_Load(object sender, EventArgs e)
        {
            updateData();
        }

        private void updateData()
        {

            dataGridView1.DataSource = DatabaseHelper.SelectGroupsAdapter();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Name = "Группа";

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            new groupModal(groupModal.type.create, null, ()=>
            {
                updateData();
            }).ShowDialog();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Group group = new Group()
            {
                Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value),
                Name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
            };

            new groupModal(groupModal.type.edit, group, () =>
            {
                updateData();
            }).ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Group group = new Group()
            {
                Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value),
                Name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
            };
            if(MessageBox.Show("Вы действительно хотите удалить эту группу?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseHelper.DeleteGroup(group);
                updateData();
            }
        }
    }
}
