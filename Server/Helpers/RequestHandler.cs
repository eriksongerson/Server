using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

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
            try
            {
                networkStream = TcpClient.GetStream();
                byte[] buffer = new byte[256];
                while (true)
                {
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
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                networkStream?.Close();
                TcpClient?.Close();
            }
        }

    }
}
