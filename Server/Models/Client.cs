﻿using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

using Server.Helpers;

namespace Server.Models
{
    public class Client
    {
        public string ip;
        public string pc;
        public string surname;
        public string name;
        public Group group;

        public void Disconnect()
        {
            new Thread(() => 
            {
                try
                {
                    int port = 32769;

                    TcpClient tcpClient = null;

                    tcpClient = new TcpClient(ip, port);

                    NetworkStream networkStream = tcpClient.GetStream();

                    Request request = new Request()
                    {
                        client = null,
                        request = "disconnect",
                        body = "disconnected",
                    };

                    string message = JsonConvert.SerializeObject(request, Formatting.Indented);

                    byte[] data = Encoding.Unicode.GetBytes(message);
                    networkStream.Write(data, 0, data.Length);

                    data = new byte[1_048_576];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = networkStream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (networkStream.DataAvailable);

                    tcpClient.Close();
                }
                catch(SocketException) 
                { 
                    return;    
                }
            }).Start();
        }

        public bool isAlive()
        {
            try 
            { 
                int port = 32769;

                TcpClient tcpClient = null;

                tcpClient = new TcpClient(ip, port);

                NetworkStream networkStream = tcpClient.GetStream();

                Request request = new Request()
                {
                    client = null,
                    request = "isAlive",
                    body = null,
                };

                string message = JsonConvert.SerializeObject(request, Formatting.Indented);

                byte[] data = Encoding.Unicode.GetBytes(message);
                networkStream.Write(data, 0, data.Length);

                data = new byte[1_048_576];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = networkStream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (networkStream.DataAvailable);

                tcpClient.Close();

                return true;
            }
            catch (SocketException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
