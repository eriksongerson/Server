using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Management;
using System.Windows.Forms;
using Server.Models;
using Server.Forms;
namespace Server.Helpers {
    // Класс SocketHelper управляет сокетом, который обрабатывает подключившиеся клиенты
    public static class SocketHelper {
        private const int port = 32768; // порт
        // Прослушиватель. Получаем для него IP адрес и указываем порт
        private static TcpListener tcpListener = null;
        private static volatile bool _status = false; // Переменная статуса
        // Поле статуса
        public static bool Status {
            // функция set будет выполняться каждый раз, когда статус будет получать новое значение
            set {
                // сохранение значения в переменную
                _status = value;
                // Если состояние - включено
                if (_status) {
                    // Начинаем прослушивание
                    StartListener(); 
                }
                // Иначе останавливаем прослушивание
                else {
                    StopListener();
                }
            }
            // функция для возврата значения статуса
            get => _status; 
        }
        // Функция, которая меняет состояние статуса на противоположное
        public static void ChangeStatus() => Status = !Status;
        // Функция получения IP сервера
        public static void ConfigureListener() {
            // Прослушиватель. Получаем для него IP адрес и указываем порт
            tcpListener = new TcpListener(IPAddress.Parse(GetLocalIpAddress()), port); 
        }
        // функция, возвращающая IP-адрес сервера
        public static string GetListenerIP() {
            return tcpListener.LocalEndpoint.ToString().Split(':')[0];
        }
        // autoResetEvent позволит приостанавливать поток
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(true);
        // Поток, в котором выполняется прослушивание
        private static Thread processingOfListening = new Thread(() => {
            processingOfListening.IsBackground = true; // Говорим потоку, что он здесь не главный
            while (true) {
                autoResetEvent.WaitOne(); // autoResetevent приостанавливает выполнение потока
                // Пока статус true
                while (Status) {
                    // Выполняется прослушивание
                    TcpClient tcpClient; 
                    try {
                        // Принимаем клиент
                        tcpClient = tcpListener.AcceptTcpClient(); 
                        // И направляем его на обработку
                        new Thread(() => {
                            Thread.CurrentThread.IsBackground = true;
                            RequestHandler requestHandler = new RequestHandler(tcpClient);
                            requestHandler.Process();
                        }).Start();
                    }
                    catch (SocketException) { continue; }
                }
            }
        });
        // Функция начала прослушивания соединений
        public static void StartListener() {
            tcpListener.Start(); // Запускаем сокет
            // Запускаем поток прослушивания
            if(processingOfListening.ThreadState == ThreadState.Unstarted) {
                processingOfListening.Start();
            }
            // активируем autoResetEvent, чтобы он пропустил цикл
            autoResetEvent.Set();
            // Запускаем новый поток, который проверяет каждую секунду что клиент подключен
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                while (Status) {
                    var testings = ClientHandler.testings;
                    if(testings.Count != 0) {
                        // Перебираем всех подключенных клиентов
                        foreach (var item in testings.ToArray()) {
                            // Если они в действительности не работают
                            if (!item.Client.isAlive()) {
                                item.Client.Disconnect(); // Отправляем им сообщение об отключении от сервера
                                ClientHandler.removeClient(item.Client); // И удаляем их массива клиентов
                            }
                        }
                    }
                    Thread.Sleep(1000); // Приостанавливаем поток на секунду и он повторяет выполнение
                }
            }).Start();
        }
        // Функция остановки прослушивания соединений
        public static void StopListener() {
            tcpListener.Stop(); // Останавливаем сокет
            // Отключаем всех подключеных клиентов:
            foreach (Testing testing in ClientHandler.testings) {
                testing.Client.Disconnect(); 
            }
            ClientHandler.testings.Clear();
        }
        // Функция получения локального IP адреса
        public static string GetLocalIpAddress() {
            var list = GetIpAddresses(); // Получаем список IP адресов системы
            // Если список пустой - программа выполняться не может
            if (list.Count == 0) {
                MessageBox.Show("На компьютере не найдено ни одного сетевого адаптера. Работа программы невозможна.");
                Application.Exit();
            }
            // Если в списке больше одного адреса - необходимо выбрать тот адрес, на котором будет работать сервер
            if (list.Count > 1) {
                // Получаем тот адрес, который сохранён в настройках
                string settingsAddress = Properties.Settings.Default.address; 
                foreach (IPAddress item in list) {
                    // Если хоть один адрес в списке совпадает с адресом, указанным в настройках
                    if (item.ToString() == settingsAddress) {
                        return item.ToString(); // Возвращаем этот адрес
                    }
                }
                // Создаём пустой объект адреса
                IPAddress address = null;
                // Создаём новую форму AddressChoosingForm
                AddressChoosingForm addressChoosingForm = new AddressChoosingForm(list, (choosen) => {
                    // Задаём форме функцию, которую она должна исполнить по определённому действию
                    // она должна сохранить выбранный адрес в переменную address, которая объявлена выше
                    address = choosen; 
                    Properties.Settings.Default.address = address.ToString();
                    // и сохранить выбранный адрес в настройки
                    Properties.Settings.Default.Save(); 
                });
                // открываем форму и ожидаем её закрытия
                // по закрытии формы возвращаем выбранный адрес
                while (addressChoosingForm.ShowDialog() != DialogResult.OK)
                    return address.ToString(); 
            }
            // Если в списке IP адресо только один адрес - возвращаем его
            return list[0].ToString(); 
        }
        // Представленный ниже код не был написан автором данный системы.
        // Автор задал вопрос на ru.stackoverflow.com и скопировал код из ответа
        // Вопрос: https://ru.stackoverflow.com/questions/830562/c-%d1%84%d0%b8%d0%bb%d1%8c%d1%82%d1%80%d0%b0%d1%86%d0%b8%d1%8f-ip-%d0%b0%d0%b4%d1%80%d0%b5%d1%81%d0%be%d0%b2

        //Определяет, является ли адаптер физическим
        public static bool IsAdapterPhysical(string guid) {
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher(
            "SELECT PhysicalAdapter FROM Win32_NetworkAdapter WHERE GUID = '" + guid + "'" );
            bool res = false;
            using (mbs) {
                mbsList = mbs.Get();
                foreach (ManagementObject mo in mbsList) {
                    foreach (var p in mo.Properties) {
                        if (p.Value != null) {
                            res = (bool)p.Value;
                            break;
                        }
                        else res = false;
                    }
                }
                return res;
            }
        }
        //Получает все локальные IP-адреса
        public static List<IPAddress> GetIpAddresses() {
            List<IPAddress> res = new List<IPAddress>();
            var ifs = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var interf in ifs) {
                var ipprop = interf.GetIPProperties();
                if (ipprop == null) continue;
                var unicast = ipprop.UnicastAddresses;
                if (unicast == null) continue;
                // Проверка на физический адрес
                if (IsAdapterPhysical(interf.Id.ToString())) {
                    foreach (var addr in unicast) {
                        if (addr.Address.AddressFamily != AddressFamily.InterNetwork) continue;
                        res.Add(addr.Address);
                        break;
                    }
                }
            }
            return res;
        }
    }
}
