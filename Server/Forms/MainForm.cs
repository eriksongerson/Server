using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Server.Helpers;

namespace Server
{
    public partial class MainForm : Form
    {

        //https://msdn.microsoft.com/ru-ru/library/7a2f3ay4(v=vs.80).aspx

        //Label NoOneConnected = new Label();
        //public static Thread WorkingThread = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void запуститьСерверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void остановитьСерверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (Server.get_isEnabled() == false)
            //{
            //    StartServer();
            //}
            //else if (Server.get_isEnabled() == true)
            //{
            //    StopServer();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBase DBForm = new DataBase();
            DBForm.Show();
        }

        private void StartServer()
        {
            //Server.set_isEnabled(true);

            //запуститьСерверToolStripMenuItem.Enabled = false;
            //button1.Text = "Остановить сервер";
            //остановитьСерверToolStripMenuItem.Enabled = true;
            //label1.Text = "Сервер запущен.";
            //label2.Text = "0 подключено.";
            //radioButton2.Enabled = false;
            //radioButton1.Enabled = false;
        }

        private void StopServer()
        {
            //Server.Clients.Clear();
            //Server.ClientInfo.Clear();
            //Server.set_isEnabled(false);
            
            //запуститьСерверToolStripMenuItem.Enabled = true;
            //button1.Text = "Запустить сервер";
            //остановитьСерверToolStripMenuItem.Enabled = false;
            //label1.Text = "Сервер отключен.";
            //label2.Text = "";
            //radioButton2.Enabled = true;
            //radioButton1.Enabled = true;
        }

        private void Main_Leave(object sender, EventArgs e)
        {
            SocketHelper.StopListener();
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SocketHelper.StartListener();

            //NoOneConnected = label5;
            //radioButton1.Text = Server.GetLocalIP();

            //timer1.Start();

            //WorkingThread = new Thread(delegate ()
            //{
            //    Thread.Sleep(30);
            //    SocketController.MultiSocket();
            //});
            //WorkingThread.Start();

            //while (!WorkingThread.IsAlive) ;

        }

        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton2.Checked == true)
        //    {
        //        Server.set_isDebug(true);
        //    }
        //}

        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton1.Checked == true)
        //    {
        //        Server.set_isDebug(false);
        //    }
        //}

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
            Journal J = new Journal();
            J.Show();
        }
    }
}
