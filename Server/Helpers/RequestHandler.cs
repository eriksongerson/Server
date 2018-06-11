using System;
using System.Text;
using System.Net.Sockets;
using System.IO;

using Server.Models;
using Newtonsoft.Json;

namespace Server.Helpers
{
    // Класс RequestHandler получает запросы от клиента
    public class RequestHandler
    {
        // объект tcpclient представляет из себя сокет, который открыт на стороне клиента
        private TcpClient _tcpClient;
        public TcpClient TcpClient
        {
            set { _tcpClient = value; }
            get { return _tcpClient; }
        }
        // Конструктор:
        public RequestHandler(TcpClient tcpClient)
        {
            this.TcpClient = tcpClient;
        }
        // Функция получения запроса
        public void Process()
        {
            NetworkStream networkStream = null; // Подготавливаем сетевой поток
            byte[] buffer = new byte[1_048_576]; // Подготавливаем буфер для получения сообщения на 1МБ
            try
            {
                networkStream = TcpClient.GetStream(); // Открываем соединение с клиентом и получаем поток
               
                // Получаем сообщение от клиента:
                StringBuilder stringBuilder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = networkStream.Read(buffer, 0, buffer.Length);
                    stringBuilder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                }
                while (networkStream.DataAvailable);
                string message = stringBuilder.ToString();
                // Преобразовываем сообщение в объект запроса
                Request request = JsonConvert.DeserializeObject<Request> (message);
                // Обрабатываем запрос
                message = request.Handle();
                // если запрос обработался неверно, вызываем исключение
                if (message == null || message.Length == 0)
                {
                    throw new NullReferenceException();
                }
                // иначе отправляем ответ клиенту
                buffer = Encoding.Unicode.GetBytes(message);
                networkStream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                if(ex is NullReferenceException || ex is IOException)
                {
                    // Указываем клиенту о наличии проблемы
                    Response response = new Response()
                        {
                            response = "problem",
                            body = JsonConvert.SerializeObject(null, Formatting.Indented),
                        };
                    string message = JsonConvert.SerializeObject(response, Formatting.Indented);
                    // отправляем сообщение
                    buffer = Encoding.Unicode.GetBytes(message);
                    networkStream.Write(buffer, 0, buffer.Length);
                }
            }
            finally
            {
                // Закрываем поток и сокет
                networkStream.Close();
                TcpClient.Close();
            }
        }

    }
}
