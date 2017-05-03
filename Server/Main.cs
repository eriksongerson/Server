using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Main : Form
    {

        //https://msdn.microsoft.com/ru-ru/library/7a2f3ay4(v=vs.80).aspx

        InterfaceController ifController = new InterfaceController();
        SocketController socketControl = new SocketController();

        public static Thread MultiThread = null;
        public Thread InterfaceChangerThread = null;
        public Thread WorkThread = null;

        Label NoOneConnected = null;

        //public Thread ListenThread = null;
        //public Thread STQThread = null;
        //public Thread AnswerThread = null;

        public Main()
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
            if (Server.get_isEnabled() == false)
            {
                StartServer();
            }
            else if (Server.get_isEnabled() == true)
            {
                StopServer();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBase DBForm = new DataBase();
            DBForm.Show();
        }

        private void StartServer()
        {
            Server.set_isEnabled(true);

            //MultiThread = new Thread(new ThreadStart(socketControl.MultiSocket));
            //InterfaceChangerThread = new Thread(new ThreadStart(IfUpdater));

            WorkThread = new Thread(new ThreadStart(StartAllThreads));
            WorkThread.Start();

            while (!WorkThread.IsAlive) ;

            Thread.Sleep(1);

            запуститьСерверToolStripMenuItem.Enabled = false;
            button1.Text = "Остановить сервер";
            остановитьСерверToolStripMenuItem.Enabled = true;
            label1.Text = "Сервер запущен.";
            label2.Text = "0 подключено.";
            radioButton2.Enabled = false;
            radioButton1.Enabled = false;
        }

        private void StopServer()
        {
            Server.set_isEnabled(false);
            
            запуститьСерверToolStripMenuItem.Enabled = true;
            button1.Text = "Запустить сервер";
            остановитьСерверToolStripMenuItem.Enabled = false;
            label1.Text = "Сервер отключен.";
            label2.Text = "";
            radioButton2.Enabled = true;
            radioButton1.Enabled = true;
            Server.Clients.Clear();
            Server.ClientInfo.Clear();
        }

        private void Main_Leave(object sender, EventArgs e)
        {
            if (Server.get_isEnabled() == true)
            {
                StopServer();
            }
            Environment.Exit(1);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            NoOneConnected = label5;
            radioButton1.Text = Server.GetLocalIP();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                Server.set_isDebug(true);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Server.set_isDebug(false);
            }
        }

        private void StartAllThreads()
        {
            MultiThread = new Thread(new ThreadStart(socketControl.MultiSocket));

            MultiThread.Start();
            while (!MultiThread.IsAlive) ;

            InterfaceChangerThread = new Thread(new ThreadStart(IfUpdater));

            InterfaceChangerThread.Start();
            while (!InterfaceChangerThread.IsAlive) ;

            while (Server.get_isEnabled()) ;

        }

        private void IfUpdater()
        {
            this.Invoke(new MethodInvoker(delegate { timer1.Start(); }));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (Server.get_isEnabled() == true)
            {
                List<string> Clients = Server.Clients;
                List<string> ClientInfo = Server.ClientInfo;
                if (Clients.Count != 0)
                {
                    this.Invoke(new MethodInvoker(delegate { label5.Visible = false; }));
                    this.Invoke(new MethodInvoker(delegate { label2.Text = Clients.Count + " подключено."; }));
                    this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Clear(); }));
                    foreach (string i in Clients)
                    {

                        Label L = new Label();
                        L.Name = i;
                        L.Font = new Font("Microsoft Sans Serif", 10);
                        L.Size = new Size(379, 36);
                        L.Text = "";
                        foreach (string j in ClientInfo)
                        {
                            string[] Line = j.Split(':');
                            if (Line[0] == i)
                            {
                                L.Text = Line[0] + ": " + Line[1] + "/" + Line[2] + " решено.";
                            }
                        }
                        if (L.Text == "")
                        {
                            L.Text = i;
                        }
                        this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Add(L); }));
                    }
                }
                else
                {
                    this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Clear(); }));
                    this.Invoke(new MethodInvoker(delegate { flowLayoutPanel1.Controls.Add(NoOneConnected); }));
                }
            }
        }

    }
}
