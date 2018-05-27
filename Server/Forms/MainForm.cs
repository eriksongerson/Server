using System;
using System.Threading;
using System.Windows.Forms;

using Server.Helpers;

namespace Server.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void запуститьСерверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeStatus();
        }

        private void остановитьСерверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeStatus();
        }

        private void ChangeStatus()
        {
            SocketHelper.ChangeStatus();
            if (SocketHelper.Status)
            {
                statusLabel.Text = "Сервер запущен";
                button1.Text = "Остановить сервер";
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    while (SocketHelper.Status)
                    {
                        connectedLabel.BeginInvoke((MethodInvoker)(() => {
                            connectedLabel.Text = $"Подключено {ClientHandler.testings.Count} студентов";
                        }));
                        Thread.Sleep(1000);
                    }
                }).Start();
            }
            else
            {
                statusLabel.Text = "Сервер отключен";
                button1.Text = "Запустить сервер";
                connectedLabel.Text = "";
            }
        }

        private void databaseButton_Click(object sender, EventArgs e)
        {
            DataBase dataBaseForm = new DataBase();
            dataBaseForm.Show();
        }

        private void Main_Leave(object sender, EventArgs e)
        {
            SocketHelper.StopListener();
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label4.Text = SocketHelper.GetListenerIP();
        }    

        private void button3_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.Show();
        }

        bool check = false;
        private void connectedLabel_Click(object sender, EventArgs e)
        {
            if(SocketHelper.Status)
                new VisaulizationForm().ShowDialog();
        }

        private void groupsButton_Click(object sender, EventArgs e)
        {
            new GroupsForm().ShowDialog();
        }
    }
}
