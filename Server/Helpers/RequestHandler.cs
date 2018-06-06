using System;
using System.Text;
using System.Net.Sockets;
using System.IO;

using Server.Models;
using Newtonsoft.Json;

namespace Server.Helpers
{
    public class RequestHandler
    {
        private TcpClient _tcpClient;
        public TcpClient TcpClient
        {
            set { _tcpClient = value; }
            get { return _tcpClient; }
        }
        public RequestHandler(){}
        public RequestHandler(TcpClient tcpClient)
        {
            this.TcpClient = tcpClient;
        }

        public void Process()
        {
            NetworkStream networkStream = null;
            byte[] buffer = new byte[1_048_576];
            try
            {
                networkStream = TcpClient.GetStream();
               
                StringBuilder stringBuilder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = networkStream.Read(buffer, 0, buffer.Length);
                    stringBuilder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                }
                while (networkStream.DataAvailable);

                string message = stringBuilder.ToString();
                
                Request request = JsonConvert.DeserializeObject<Request> (message);
                    
                message = request.Handle();
                
                if (message == null || message.Length == 0)
                {
                    throw new NullReferenceException();
                }
                buffer = Encoding.Unicode.GetBytes(message);
                networkStream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                if(ex is NullReferenceException || ex is IOException)
                {
                    Response response = new Response()
                        {
                            response = "problem",
                            body = JsonConvert.SerializeObject(null, Formatting.Indented),
                        };
                    string message = JsonConvert.SerializeObject(response, Formatting.Indented);
                
                    buffer = Encoding.Unicode.GetBytes(message);
                    networkStream.Write(buffer, 0, buffer.Length);
                }
            }
            finally
            {
                networkStream.Close();
                TcpClient.Close();
            }
        }

    }
}
