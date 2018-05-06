using System;
using System.Windows.Forms;

using Server.Helpers;
using Server.Models;

namespace Server.Forms
{
    public partial class MainForm : Form
    {
        private static ClientList _clients = new ClientList();

        public ClientList Clients
        {
            set
            {
                _clients = value;
                _clients.onLengthChanged += (sender, e) => { Clients = Clients; }; // Событие само по себе костыльное. Но оно работает.
                if (_clients != null)
                {
                    flowLayoutPanel1.Controls.Clear();
                    foreach (Client client in _clients)
                    {
                        
                    }
                }
            }
            get { return _clients; }
        }

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
                
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
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
            SocketHelper.StartListener();

            label4.Text = SocketHelper.GetLocalIpAddress();
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (Server.get_isEnabled())
        //    {
        //        List<string> Clients = Server.Clients;
        //        List<string> ClientInfo = Server.ClientInfo;
        //        if (Clients.Count != 0)
        //        {
        //            this.Invoke(new MethodInvoker(delegate { label5.Visible = false; }));
        //            if (flowLayoutPanel1.Contains(NoOneConnected)) { flowLayoutPanel1.Controls.Remove(NoOneConnected); }
        //            this.Invoke(new MethodInvoker(delegate { label2.Text = Clients.Count + " подключено."; }));
        //            this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Clear(); }));
        //            foreach (string i in Clients)
        //            {

        //                Label L = new Label();
        //                L.Name = i;
        //                L.Font = new Font("Microsoft Sans Serif", 10);
        //                L.Size = new Size(379, 36);
        //                L.Text = "";
        //                foreach (string j in ClientInfo)
        //                {
        //                    string[] Line = j.Split(':');
        //                    if (Line[0] == i)
        //                    {
        //                        L.Text = Line[0] + ": " + Line[1] + "/" + Line[2] + " решено.";
        //                    }
        //                }
        //                if (L.Text == "")
        //                {
        //                    L.Text = i;
        //                }
        //                this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Add(L); }));
        //            }
        //        }
        //        else
        //        {
        //            this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Clear(); }));
        //            this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Add(NoOneConnected); }));
        //        }
        //    }
        //    else
        //    {
        //        this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Clear(); }));
        //        this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Add(NoOneConnected); }));
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            Journal journal = new Journal();
            journal.Show();
        }
    }
}
