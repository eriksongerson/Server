using System;
using System.Windows.Forms;

using Server.Models;
using Server.Helpers;

namespace Server.Forms
{
    public partial class groupModal : Form
    {
        public enum type
        {
            create,
            edit
        }

        type Type;
        Group group;
        Execute execute;

        public delegate void Execute();

        public groupModal(type type, Group group, Execute execute)
        {
            InitializeComponent();
            this.Type = type;
            this.group = group;
            this.execute = execute;
        }

        private void groupModal_Load(object sender, EventArgs e)
        {
            switch (Type)
            {
                case type.create:
                    this.Text = "Добавление группы";
                    doThingButton.Text = "Добавить";
                    doThingButton.Click += new EventHandler((senderObject, eventArgs) => 
                    {
                        if(thingTextBox.Text != "")
                        {
                            group = new Group()
                            {
                                Name = thingTextBox.Text,
                            };
                            DatabaseHelper.InsertGroup(group);
                            execute();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Заполните название группы");
                            thingTextBox.Select();
                        }
                    });
                    break;
                case type.edit:
                    this.Text = "Изменение группы";
                    thingTextBox.Text = group.Name;
                    doThingButton.Text = "Изменить";
                    doThingButton.Click += new EventHandler((senderObject, eventArgs) => 
                    {
                        if (thingTextBox.Text != "")
                        {
                            group.Name = thingTextBox.Text;
                            DatabaseHelper.UpdateGroup(group);
                            execute();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Заполните название группы");
                            thingTextBox.Select();
                        }
                    });
                    break;
            }
            thingTextBox.Select();
        }

        private void thingTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doThingButton.PerformClick();
            }
        }
    }
}
