using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server.Helpers
{
    public static class SocketHelper
    {
        private const int port = 32768;
        private static TcpListener tcpListener = new TcpListener(IPAddress.Parse(GetLocalIpAddress()), port);

        private static bool _status = false;
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

        // TODO: нужно научиться приостанавливать поток
        private static Thread processingOfListening = new Thread(() =>
            {
                while (true)
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
            });


        public static void StartListener()
        {
            tcpListener.Start();
            processingOfListening.Start();
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
