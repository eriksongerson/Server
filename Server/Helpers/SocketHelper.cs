using System.Net;
using System.Net.Sockets;
using System.Threading;
using Server.Models;

namespace Server.Helpers
{
    public static class SocketHelper
    {
        private const int port = 32768;
        private static TcpListener tcpListener = new TcpListener(IPAddress.Parse(GetLocalIpAddress()), port);

        private static ClientList _clients = new ClientList();

        public static ClientList Clients
        {
            set
            {
                _clients = value; 
            }
            get
            {
                return _clients;
            }
        }

        private static volatile bool _status = false;
        public static bool Status
        {
            set
            {
                _status = value;
                if (_status)
                {
                    StartListener();
                }
                else
                {
                    StopListener();
                }
            }
            get { return _status; }
        }

        public static void ChangeStatus()
        {
            Status = !Status;
        }

        private static AutoResetEvent autoResetEvent = new AutoResetEvent(true);
        // TODO: нужно научиться приостанавливать поток
        private static Thread processingOfListening = new Thread(() =>
            {
                processingOfListening.IsBackground = true;
                while (true)
                {
                    autoResetEvent.WaitOne();
                    while (Status)
                    {
                        TcpClient tcpClient;
                        try
                        {
                            tcpClient = tcpListener.AcceptTcpClient();

                            new Thread(() => 
                            {
                                RequestHandler requestHandler = new RequestHandler(tcpClient);
                                requestHandler.Process();
                            }).Start();
                        }
                        catch (SocketException)
                        {
                            // TODO: не оставлять пустым
                        }
                    }
                }
            });


        public static void StartListener()
        {
            tcpListener.Start();
            if(processingOfListening.ThreadState == ThreadState.Unstarted)
            {
                processingOfListening.Start();
            }
            autoResetEvent.Set();
        }

        public static void StopListener()
        {
            tcpListener.Stop();
        }

        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }

    }
}
