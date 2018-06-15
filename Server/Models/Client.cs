using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
namespace Server.Models {
    // Объект клиента
    public class Client {
        public string ip; // IP компьютера студента
        public string pc; // Имя ПК студента
        public string surname; // Фамилия студента
        public string name; // Имя студента
        public Group group; // Группа студента
        // Функция, которая позволяет оповестить клиент о том, что он отключен от сервера
        public void Disconnect() {
            new Thread(() => {
                try {
                    int port = 32769; // порт
                    TcpClient tcpClient = new TcpClient(ip, port); // конфигурирование сокета
                    NetworkStream networkStream = tcpClient.GetStream(); // Сетевой поток
                    // новый запрос
                    Request request = new Request() {
                        client = null,
                        request = "disconnect",
                        body = null,
                    };
                    // перевод объекта запроса в строку
                    string message = JsonConvert.SerializeObject(request, Formatting.Indented);
                    // Отправка запроса
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    networkStream.Write(data, 0, data.Length);
                    // Получение ответа
                    data = new byte[1_048_576];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do {
                        bytes = networkStream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (networkStream.DataAvailable);
                    // Закрытие сокета
                    tcpClient.Close();
                } catch(SocketException) { return; }
            }).Start();
        }
        // Функция, позволяющая узнать, существует ли клиент
        public bool isAlive() {
            try { 
                int port = 32769; // порт
                TcpClient tcpClient = new TcpClient(ip, port); // конфигурирование сокета
                NetworkStream networkStream = tcpClient.GetStream(); // Сетевой поток
                // Запрос
                Request request = new Request() {
                    client = null,
                    request = "isAlive",
                    body = null,
                };
                // Перевод объекта из объекта в строку
                string message = JsonConvert.SerializeObject(request, Formatting.Indented);
                // отправка запроса
                byte[] data = Encoding.Unicode.GetBytes(message);
                networkStream.Write(data, 0, data.Length);
                // получение ответа
                data = new byte[1_048_576];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do {
                    bytes = networkStream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (networkStream.DataAvailable);
                // закрытие сокета
                tcpClient.Close();
                // Возврат значения true
                return true;
            }
            // Если есть проблемы - клиент отключен - возврат false
            catch (SocketException) { return false; }
            catch (IOException) { return false; }
        }
    }
}
