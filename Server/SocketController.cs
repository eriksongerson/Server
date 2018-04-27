using System;
using System.Text;
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
            m:
            while (Server.get_isEnabled())
            {
                
                string IP = Server.get_IP();
                IPEndPoint ipListenPoint = new IPEndPoint(IPAddress.Parse(IP), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket Handler = null;
                string Work = null;
                error:
                try
                {
                    socket.Bind(ipListenPoint);
                    socket.Listen(100);
                    while (true)
                    {
                        Handler = socket.Accept();

                        StringBuilder Message = new StringBuilder();
                        int bytes = 0;
                        byte[] data = new byte[256];
                        do
                        {
                            bytes = Handler.Receive(data);
                            Message.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (Handler.Available > 0);

                        Work = Message.ToString();
                        string message = Server.SocketHandler(Message);

                        data = Encoding.Unicode.GetBytes(message);
                        Handler.Send(data);

                        Handler.Shutdown(SocketShutdown.Both);
                        Handler.Close();

                        //Work = null;
                    }
                }
                catch (SocketException)
                {
                    if (Work != null)
                    {
                        string[] Line = Work.ToString().Split(':');
                        Server.RemoveClient(Line[1]);
                    }
                    //Handler.Shutdown(SocketShutdown.Both);
                    Handler.Close();
                    goto error;
                }
                catch (Exception)
                {
                    //Handler.Shutdown(SocketShutdown.Both);
                    Handler.Close();
                    goto error;
                }
                
            }
            while (!Server.get_isEnabled()) ;
            goto m;
        }

    }
}
