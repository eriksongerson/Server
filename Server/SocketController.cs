using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class SocketController
    {

        private static int port = 12345;
        public SocketController()
        {
           
        }

        public static void MultiSocket()
        {
            while (Server.get_isEnabled() == true)
            {
                m:
                string IP = Server.get_IP();
                IPEndPoint ipListenPoint = new IPEndPoint(IPAddress.Parse(IP), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    socket.Bind(ipListenPoint);
                    socket.Listen(100);
                    while (true)
                    {
                        Socket Handler = socket.Accept();
                        StringBuilder Message = new StringBuilder();
                        int bytes = 0;
                        byte[] data = new byte[256];
                        do
                        {
                            bytes = Handler.Receive(data);
                            Message.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (Handler.Available > 0);

                        string message = Server.SocketHandler(Message);

                        data = Encoding.Unicode.GetBytes(message);
                        Handler.Send(data);

                        Handler.Shutdown(SocketShutdown.Both);
                        Handler.Close();
                    }
                }
                catch (Exception ex)
                {
                    goto m;
                }
            }
        }

    }
}
