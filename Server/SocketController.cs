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

        /**
         * Существует три сокета.
         * Каждый выполняет свою роль.
         * 
         * Первый - ListenSocket - Слушает сеть на наличие подключившихся.
         * Второй - QuestionSocket - Слушает сеть на запросы о вопросах.
         * Третий - AnswerSocket - Слушает сеть на запросы записать ответ.
         **/

        Server srvr = new Server();
       

        //private int portForListen = 8192;
        //private int portForQuestion = 8193;
        //private int portForAnswers = 8194;

        private int port = 12345;
        public SocketController()
        {
           
        }

        public void MultiSocket()
        {
            while (Server.get_isEnabled() == true)
            {
                m:
                string IP = srvr.get_IP();
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

                        string message = srvr.SocketHandler(Message);

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

        //сокет, который будет слушать подключившихся и отключившихся
        /*public void ListenSocket()
        {
            IPEndPoint ipListenPoint = new IPEndPoint(IPAddress.Parse(srvr.get_IP()), portForListen);
            Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m:
            try
            {
                ListenSocket.Bind(ipListenPoint);
                ListenSocket.Listen(100);
                while (true)
                {
                    Socket Handler = ListenSocket.Accept();
                    StringBuilder Message = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];
                    do
                    {
                        bytes = Handler.Receive(data);
                        Message.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while ( Handler.Available > 0 );

                    string message = srvr.SocketHandler("Listen" ,Message);

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
        }*/

        //сокет, который выдаёт предметы, темы и вопросы
        /*public void STQSocket()
        {
            IPEndPoint ipListenPoint = new IPEndPoint(IPAddress.Parse(srvr.get_IP()), portForQuestion);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m:
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

                    string message = srvr.SocketHandler("STQ", Message);

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
        }*/

        //сокет, который ловит ответы
        /*public void AnswerSocket()
        {
            IPEndPoint ipListenPoint = new IPEndPoint(IPAddress.Parse(srvr.get_IP()), portForAnswers);
            Socket AnswerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m:
            try
            {
                AnswerSocket.Bind(ipListenPoint);
                AnswerSocket.Listen(100);
                while (true)
                {
                    Socket Handler = AnswerSocket.Accept();
                    StringBuilder Message = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];
                    do
                    {
                        bytes = Handler.Receive(data);
                        Message.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (Handler.Available > 0);

                    string message = srvr.SocketHandler("Answer",Message);

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
        }*/

    }
}
