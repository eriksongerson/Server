using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Management;
using System.Windows.Forms;

using Server.Models;
using Server.Forms;

namespace Server.Helpers
{
    public static class SocketHelper
    {
        private const int port = 32768;
        private static TcpListener tcpListener = new TcpListener(IPAddress.Parse(GetLocalIpAddress()), port);

        private static volatile bool _status = false;
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

        public static string GetListenerIP()
        {
            return tcpListener.LocalEndpoint.ToString().Split(':')[0];
        }

        private static AutoResetEvent autoResetEvent = new AutoResetEvent(true);
        private static Thread processingOfListening = new Thread(() =>
            {
                processingOfListening.IsBackground = true;
                while (true)
                {
                    autoResetEvent.WaitOne();
                    while (Status)
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
                }
            });


        public static void StartListener()
        {
            tcpListener.Start();
            if(processingOfListening.ThreadState == ThreadState.Unstarted)
            {
                processingOfListening.Start();
            }
            autoResetEvent.Set();
        }

        public static void StopListener()
        {
            tcpListener.Stop();
            foreach (Testing testing in ClientHandler.testings)
            {
                testing.Client.Disconnect();
            }
            ClientHandler.testings.Clear();
        }

        public static string GetLocalIpAddress()
        {
            var list = GetIpAddresses();
            if(list.Count == 0)
            {
                MessageBox.Show("На компьютере не найдено ни одного сетевого адаптера. Работа программы невозможна.");
                Application.Exit();
            }
            if(list.Count > 1)
            {
                string settingsAddress = Properties.Settings.Default.address;
                foreach (IPAddress item in list)
                {
                    if(item.ToString() == settingsAddress)
                    {
                        return item.ToString();
                    }
                }

                IPAddress address = null;
                AddressChoosingForm addressChoosingForm = new AddressChoosingForm(list, (choosen) =>
                {
                    address = choosen;
                    Properties.Settings.Default.address = address.ToString();
                    Properties.Settings.Default.Save();
                });
                while (addressChoosingForm.ShowDialog() != DialogResult.OK)
                    return address.ToString();
            }
            return list[0].ToString();
        }

        // Представленный ниже код не был написан автором данный системы.
        // Автор задал вопрос на ru.stackoverflow.com и скопировал код из ответа
        // Вопрос: https://ru.stackoverflow.com/questions/830562/c-%d1%84%d0%b8%d0%bb%d1%8c%d1%82%d1%80%d0%b0%d1%86%d0%b8%d1%8f-ip-%d0%b0%d0%b4%d1%80%d0%b5%d1%81%d0%be%d0%b2

        //Определяет, является ли адаптер физическим
        public static bool IsAdapterPhysical(string guid)
        {
            ManagementObjectCollection mbsList = null;

            ManagementObjectSearcher mbs = new ManagementObjectSearcher(
            "SELECT PhysicalAdapter FROM Win32_NetworkAdapter WHERE GUID = '" + guid + "'"
            );
            bool res = false;

            using (mbs)
            {
                mbsList = mbs.Get();

                foreach (ManagementObject mo in mbsList)
                {
                    foreach (var p in mo.Properties)
                    {
                        if (p.Value != null)
                        {
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
        public static List<IPAddress> GetIpAddresses()
        {
            List<IPAddress> res = new List<IPAddress>(10);

            var ifs = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var interf in ifs)
            {
                var ipprop = interf.GetIPProperties();
                if (ipprop == null) continue;
                var unicast = ipprop.UnicastAddresses;
                if (unicast == null) continue;

                if (IsAdapterPhysical(interf.Id.ToString()))
                {
                    //находим первый Unicast-адрес
                    foreach (var addr in unicast)
                    {
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
